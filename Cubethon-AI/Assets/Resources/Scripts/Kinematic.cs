using UnityEngine;

public class Kinematic : MonoBehaviour
{
    //public Vector3 position;
    public float orientation;
    public Vector3 velocity;
    public float rotation;
    public KinematicMovementType movementType = KinematicMovementType.seeker;
    public IKinematicSteering kinematicSteering;
    public Kinematic target;
    public Rigidbody rb;

    public void Start()
    {
        if (movementType == KinematicMovementType.seeker || movementType == KinematicMovementType.fleeer)
            kinematicSteering = new AIKinematicSteering(movementType,this, target);
        else if (movementType == KinematicMovementType.player)
            kinematicSteering = new PlayerKinematicSteering(transform);
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        kinematicMove(kinematicSteering.GetSteering());
    }

    public void kinematicMove(KinematicSteeringOutput steeringOutput)
    {
        transform.position += steeringOutput.velocity * Time.fixedDeltaTime;
        transform.eulerAngles = new Vector3(0.0f, steeringOutput.rotation, Time.fixedDeltaTime);
    }
}
