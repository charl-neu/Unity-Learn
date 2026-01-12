using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 45.0f; // rotation in degrees per second
    [SerializeField] float fireCooldown = 1.0f; // seconds between shots
    [SerializeField] Ammo ammo;
    [SerializeField] Transform muzzle;

    float fireTimer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireTimer = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer < 0.0f)
        {
            fireTimer = fireCooldown;
            Instantiate(ammo, muzzle.position, muzzle.rotation);
        }

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
