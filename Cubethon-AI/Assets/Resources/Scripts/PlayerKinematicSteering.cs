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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        KinematicSteeringOutput result = new KinematicSteeringOutput();
        
        result.velocity = character.forward * z + character.right * x;
        result.velocity.Normalize();

        result.velocity *= maxSpeed;

        result.rotation = NewOrientation(character.eulerAngles.y, result.velocity);

        if (z == 0)
            result.velocity = new Vector3(0,0,0);

        return result;
    }
   
    float NewOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
            return Mathf.MoveTowardsAngle(current, 180 * Mathf.Atan2(velocity.x, velocity.z) / Mathf.PI, maxRotationSpeed);
        else
            return current;
    }
}