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
        UpdatePosition(kinematicSteering.GetSteering(), Time.deltaTime);
    }

    public void UpdatePosition(KinematicSteeringOutput steeringOutput, float time)
    {

        rb.MovePosition(transform.position + transform.forward * steeringOutput.velocity.magnitude * Time.deltaTime);
        transform.eulerAngles = new Vector3(0.0f, steeringOutput.rotation, 0.0f);

        //velocity += steeringOutput.linear * Time.deltaTime;
        //rotation += steeringOutput.angular * Time.deltaTime;
    }
}
