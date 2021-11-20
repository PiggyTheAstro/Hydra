using UnityEngine;
public interface IMovementComponent
{
    Vector3 MovementDirection();
    void MultiplyIntensity(float multiplier);
}
