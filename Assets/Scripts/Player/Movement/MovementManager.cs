using Hydra.Parsing;
using System.Collections.Generic;
using UnityEngine;
public class MovementManager : MonoBehaviour, IPhysicsController // Controls the movement of the player
{
    private List<IMovementComponent> components;
    [SerializeField] private CharacterController controller;
    [SerializeField] private string[] serializedComponents;
    private void Awake()
    {
        components = new List<IMovementComponent>();
        for (int i = 0; i < serializedComponents.Length; i++)
        {
            components.Add(StringParser.instance.StringToInstance(serializedComponents[i]) as IMovementComponent);
            components[i].Init(transform);
        }
    }

    private void Update() // Loops through all components and gets their desired movement, then merges them into 1 vector
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
