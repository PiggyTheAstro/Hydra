using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour, IPhysicsController
{
    private List<IMovementComponent> components;
    [SerializeField] private CharacterController controller;
    bool overriden;
    private void Start()
    {
        components = new List<IMovementComponent>();
        components.Add(GetComponent<PlayerMovement>());
        components.Add(GetComponent<JumpManager>());
        components.Add(GetComponent<DashManager>());
    }
    void Update()
    {
        if(overriden)
        {
            overriden = false;
            return;
        }
        Vector3 movement = new Vector3();

        for(int i = 0; i < components.Count; i++)
        {
            movement += components[i].MovementDirection();
        }

        controller.Move(movement * Time.deltaTime);
    }
    public void SetMultiplier(float multiplier, int index)
    {
        components[index].MultiplyIntensity(multiplier);
    }
    public Transform GetTransform()
    {
        return transform;
    }
    public void Move(Vector3 dir, float speed)
    {
        controller.Move(dir * speed * Time.deltaTime);
        overriden = true;
    }
}
