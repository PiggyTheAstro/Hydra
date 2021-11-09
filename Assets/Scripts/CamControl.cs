using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    Transform player;
    [SerializeField] float sensitivity;
    float yRotation;
    void Start()
    {
        player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); // TODO: Separate input into a separate class
        player.Rotate(new Vector3(0f, input.x * sensitivity, 0f));
        yRotation -= input.y * sensitivity;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
}
