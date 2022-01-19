using UnityEngine;

public class PlayerKinematicSteering : IKinematicSteering
{
    Transform character;
    KinematicMovementType movementType;

    const float maxSpeed = 2.0f;
    const float maxRotationSpeed = 5.0f;

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

        result.rotation = NewOrientation(x);

        return result;
    }

    float NewOrientation(float rotDir)
    {
        return rotDir * maxRotationSpeed;
    }
}
