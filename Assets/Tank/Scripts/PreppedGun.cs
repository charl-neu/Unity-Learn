using UnityEngine;

public class PreppedGun : MonoBehaviour
{
    [SerializeField] float fireCooldown = 1.0f; // seconds between shots
    [SerializeField] Ammo ammo;
    [SerializeField] Transform muzzle;
    [SerializeField] RaycastPerception perception;

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
        GameObject[] players = perception.GetGameObjects();


        if (fireTimer < 0.0f && players.Length != 0)
        {
            fireTimer = fireCooldown;
            Instantiate(ammo, muzzle.position, muzzle.rotation);
        }

    }
}
