using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int scoreValue = 100;
    [SerializeField] float maxHealth = 10.0f;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    [SerializeField] UnityEvent destroyEvent;
    private float hp;
    public float HP
    {
        get { return hp; }
        set { hp = Mathf.Clamp(value, 0.0f, maxHealth); }
    }

    public float CurrentHealthPercentage
    {
        get { return HP / maxHealth; }
    }
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
            TankGameManager.Instance.Score += scoreValue;

            if (destroyEffect != null)
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            destroyed = true;
            destroyEvent?.Invoke();

            Destroy(gameObject);
        } else if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }

    public void OnHeal(float healAmount)
    {
        HP += healAmount;
    }

}
