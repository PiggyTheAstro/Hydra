using UnityEngine;
public interface IMovementComponent // All classes affecting movement have to implement this
{
    void Init(Transform parent);
    void Tick();
    Vector3 MovementDirection();
    void MultiplyIntensity(float multiplier);
}
