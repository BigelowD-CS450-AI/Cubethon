using UnityEngine;

public class AIKinematicSteering : IKinematicSteering
{
    Kinematic character;
    Kinematic target;
    KinematicMovementType movementType;

    const float maxSpeed = 1.0f;

    public AIKinematicSteering(KinematicMovementType moveType, Kinematic thisKinematic, Kinematic target)
    {
        movementType = moveType;
        this.target = target;
        character = thisKinematic;
    }

    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        if (movementType == KinematicMovementType.seeker)
            result.velocity = target.transform.position - character.transform.position;
        else if (movementType == KinematicMovementType.fleeer)
            result.velocity = character.transform.position - target.transform.position;
        result.velocity.Normalize();
        result.velocity.y = 0;
        result.velocity *= maxSpeed;

        result.rotation = NewOrientation(character.transform.eulerAngles.y, result.velocity);

        return result;
    }

    float NewOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
            return 180 * Mathf.Atan2(velocity.x, velocity.z) / Mathf.PI;
        else
            return current;
    }
}
