using Unity.VisualScripting;
using UnityEngine;

public class HitScan : Ammo
{
    [SerializeField] float distance = 100.0f;
    [SerializeField] LayerMask layerMask = Physics.AllLayers;

    [SerializeField] GameObject hitEffect;

    private void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, distance, layerMask))
        {
            // check if hit object has health component
            Health health = raycastHit.collider.gameObject.GetComponent<Health>();
            if (health != null)
            {
                // deal damage to hit object
                health.TakeDamage(damage);
            }
            if (hitEffect != null)
            {
                Instantiate(hitEffect, raycastHit.point, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }

}
