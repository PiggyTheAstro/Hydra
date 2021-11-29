using UnityEngine;

public class HitInfo
{
    public Vector3 hitDir;
    public float hitStrength;
    public HitInfo(Vector3 hitDirection, float hitForce)
    {
        hitDir = hitDirection;
        hitStrength = hitForce;
    }
}
