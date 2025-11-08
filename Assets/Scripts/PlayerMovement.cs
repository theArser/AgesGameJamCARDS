using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector3 input = context.ReadValue<Vector3>();

        rb.AddForce(
            (transform.right * input.x * 10f +
            playerCamera.forward * input.z * 10f +
            Vector3.up * input.y * 10f).normalized * 10f
        );
    }

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, input.x * 0.1f);
        playerCamera.Rotate(Vector3.right, -input.y * 0.1f);

        
    }

}
