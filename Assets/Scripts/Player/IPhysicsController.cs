using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicsController
{
    void SetSpeedMultiplier(float multiplier);
    void SetJumpAbility(bool val);

    void SetDashAbility(bool val);
    void Move(Vector3 dir, float speed);
    Transform GetTransform();
}
