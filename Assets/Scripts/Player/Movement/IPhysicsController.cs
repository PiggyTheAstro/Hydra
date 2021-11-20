using UnityEngine;

public interface IPhysicsController
{
    void SetMultiplier(float multiplier, int index);
    void Move(Vector3 dir, float speed);
    Transform GetTransform();
}
