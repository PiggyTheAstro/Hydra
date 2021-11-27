using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour, IDamageable
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnDamage()
    {
        rb.AddForce(Vector3.up * 10000f, ForceMode.Impulse);
    }
}
