using UnityEngine;

public class DummyScript : MonoBehaviour, IDamageable
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnDamage(HitInfo hitInfo)
    {
        rb.AddForce((Vector3.up + new Vector3(hitInfo.hitDir.x, 0f, hitInfo.hitDir.z)) * hitInfo.hitStrength * 1000f, ForceMode.Impulse);
    }
}
