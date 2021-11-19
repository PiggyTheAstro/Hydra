using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicsController
{
    void SetSpeedMultiplier(float multiplier);
    void SetJumpAbility(bool val);
    Transform GetTransform();
}
