using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    private Transform player;
    private float yRotation;

    private void Start()
    {
        player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        Vector2 input = new Vector2(InputManager.singleton.MouseX, InputManager.singleton.MouseY);
        player.Rotate(new Vector3(0f, input.x * sensitivity, 0f));
        yRotation -= input.y * sensitivity;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
}
