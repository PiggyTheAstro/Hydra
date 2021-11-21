using UnityEngine;

public class InputManager : MonoBehaviour // TODO: Reevaluate if this should be a monobehaviour
{
    public static InputManager singleton;
    private float horizontalAxis;
    private float verticalAxis;
    private float mouseX;
    private float mouseY;
    private bool attack;
    private bool block;
    private bool jump;
    private bool dash;
    public float HorizontalAxis { get => horizontalAxis; }
    public float VerticalAxis { get => verticalAxis; }
    public float MouseX { get => mouseX; }
    public float MouseY { get => mouseY; }
    public bool Attack { get => attack; }
    public bool Block { get => block; }
    public bool Jump { get => jump; }
    public bool Dash { get => dash; }

    private void Awake() // TODO: Add functionality once you have more than 1 scene
    {
        if (singleton == null)
        {
            singleton = this;
        }
    }

    private void Update() // TODO: Add customizable input keys
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        attack = Input.GetMouseButton(0);
        block = Input.GetMouseButton(1);
        jump = Input.GetKey(KeyCode.Space);
        dash = Input.GetKeyDown(KeyCode.LeftShift);
    }
}
