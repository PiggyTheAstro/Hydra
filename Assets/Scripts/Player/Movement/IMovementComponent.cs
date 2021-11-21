using UnityEngine;
public interface IMovementComponent
{
    void Init(Transform parent);
    void Tick();
    Vector3 MovementDirection();
    void MultiplyIntensity(float multiplier);
}
