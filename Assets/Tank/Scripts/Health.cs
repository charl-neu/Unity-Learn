using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 10.0f;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    public float HP { get; set; }
    bool destroyed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (destroyed) return;

        HP -= damage;
        if (HP <= 0.0f)
        {
            if (destroyEffect != null)
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            destroyed = true;
            Destroy(gameObject);
        } else if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }

}
