using UnityEngine;

public class PlayerKinematicSteering : IKinematicSteering
{
    Transform character;
    KinematicMovementType movementType;

    const float maxSpeed = 2.0f;
    const float maxRotationSpeed = 10.0f;

    public PlayerKinematicSteering(Transform transform)
    {
        character = transform;
    }

    public KinematicSteeringOutput GetSteering()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = character.forward * z;
        result.velocity.Normalize();

        result.velocity *= maxSpeed;

        result.rotation = NewOrientation(character.eulerAngles.y, result.velocity);

        if (z == 0)
            result.velocity = new Vector3(0,0,0);

        Debug.Log("result v " + result.velocity.magnitude);
        Debug.Log("result r " + result.rotation);
        return result;
    }
   
    float NewOrientation(float current, Vector3 velocity)
    {
        return rotDir * maxRotationSpeed;
    }
}
