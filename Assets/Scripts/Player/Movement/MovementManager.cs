using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour, IPhysicsController
{
    private List<IMovementComponent> components;
    [SerializeField] private CharacterController controller;
    private void Awake()
    {
        components = new List<IMovementComponent>();
        components.Add(new PlayerMovement());
        components.Add(new JumpManager());
        components.Add(new DashManager());
        for (int i = 0; i < components.Count; i++)
        {
            components[i].Init(transform);
        }
    }

    private void Update()
    {
        Vector3 movement = new Vector3();
        for (int i = 0; i < components.Count; i++)
        {
            components[i].Tick();
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
    }
}
