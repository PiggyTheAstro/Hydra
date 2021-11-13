using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour // Class is not descriptive and should be renamed. Also, reevaluate the hit detection method
{
    public List<GameObject> collided;

    private void Start()
    {
        collided = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag != "Enemy" || collided.Contains(col.gameObject)) // Stop checking against the name
        {
            return;
        }
        collided.Add(col.gameObject);
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag != "Enemy") // Stop checking against the name
        {
            return;
        }
        try
        {
            collided.Remove(col.gameObject);
        }
        catch
        {
            
        }
    }
}
