using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Tank : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 90.0f; // rotation in degrees per second

    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzle;

    [SerializeField] Slider healthBar;

    InputAction moveAction;
    InputAction lookAction;
    InputAction attackAction;

    Health health;


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        attackAction = InputSystem.actions.FindAction("Attack");

        attackAction.started += ctx => OnAttack();

        health = GetComponent<Health>();

    }
    void Update()
    {
        // direction (forward/backward movement)
        float direction = moveAction.ReadValue<Vector2>().y;        
        transform.Translate(Vector3.forward * speed * Time.deltaTime * direction);

        // rotation (left/right)
        float rotation = moveAction.ReadValue<Vector2>().x + lookAction.ReadValue<Vector2>().x;
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        // check if "Fire" key was pressed, if so instantiate the ammo (rocket)
        // ammo is instantiated at the muzzle position and rotation
        if (attackAction.WasPressedThisFrame())
        {
            // Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
        }

        healthBar.value = health.CurrentHealthPercentage;
    }

    void OnAttack()
    {
        Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
    }
}