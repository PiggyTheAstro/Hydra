using UnityEngine;

public class DummyScript : MonoBehaviour, IDamageable
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnDamage()
    {
        rb.AddForce(Vector3.up * 10000f, ForceMode.Impulse);
    }
}
