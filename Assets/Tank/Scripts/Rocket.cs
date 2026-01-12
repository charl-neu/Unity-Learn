using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket : Ammo
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed = .25f;
    [SerializeField] float lifetime = 5.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
