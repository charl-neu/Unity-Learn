using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private float amount;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HealthPickup triggered by: " + other.name);
        if (other.TryGetComponent(out Health health))
        {
            health.OnHeal(amount);
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
