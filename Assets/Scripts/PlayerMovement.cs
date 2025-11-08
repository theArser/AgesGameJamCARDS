using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    private Vector2 cameraRotation;
    private Vector3 movementInput;
    [SerializeField][Range(0.1f, 1f)] private float cameraSensitivity = 0.5f;
    private const float cameraSensitivityMultiplier = 0.1f;
    [SerializeField][Range(0.1f, 1f)] private float movementSpeed = 1f;
    private const float movementSpeedMultiplier = 20f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = movementSpeed * movementSpeedMultiplier;
        rb.AddForce(
            transform.right * movementInput.x * speed +
            playerCamera.forward * movementInput.z * speed +
            Vector3.up * movementInput.y * speed
        );
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector3>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        cameraRotation.x += input.x * cameraSensitivity * cameraSensitivityMultiplier;
        if (cameraRotation.x > 360f) cameraRotation.x -= 360f;
        if (cameraRotation.x < 0f) cameraRotation.x += 360f;
        cameraRotation.y -= input.y * cameraSensitivity * cameraSensitivityMultiplier;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0f, cameraRotation.x, 0f);
        playerCamera.localRotation = Quaternion.Euler(cameraRotation.y, 0f, 0f);
    }

}
