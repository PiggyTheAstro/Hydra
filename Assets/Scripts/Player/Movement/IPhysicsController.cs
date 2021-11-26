using UnityEngine;
public interface IPhysicsController // Component for controlling multi-channel movement
{
    void SetMultiplier(float multiplier, int index);
    void Move(Vector3 dir, float speed);
    Transform GetTransform();
}
