using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Baller : MonoBehaviour
{
    [SerializeField, Range(0,50)] float moveForce = 3;
    [SerializeField, Range(0,50)] float jumpForce = 3;
    [SerializeField] Transform view;

    [Header("Ground Collision")]
    [SerializeField, Range(0, 5)] float rayLength = 1;
    [SerializeField] LayerMask groundlayerMask = Physics.AllLayers;

    Rigidbody rb;
    Vector2 inputMovement;

    InputAction moveAction;
    InputAction jumpAction;

    private void Awake()
    {
        //if view isnt set get from main camera
        view ??= Camera.main.transform;
        moveAction= InputSystem.actions.FindAction("Move");
        jumpAction= InputSystem.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        jumpAction.started += OnJump;

        InputSystem.actions.FindActionMap("Player").Enable();
        InputSystem.actions.FindActionMap("UI").Enable();
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;

        jumpAction.started -= OnJump;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
    }

    private void FixedUpdate()
    {
        //convert controller space to world space
        Vector3 movement = new Vector3(inputMovement.x, 0, inputMovement.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * movement;
        rb.AddForce(movement * moveForce, ForceMode.Force);
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        inputMovement = ctx.ReadValue<Vector2>();
    }
    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (!OnGround()) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool OnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundlayerMask);
       
    }
}
