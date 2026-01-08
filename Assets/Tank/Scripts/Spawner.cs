using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float spawntimer = 1.0f;
    [SerializeField] GameObject spawnObject;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.IsPressed())
        {
            Vector3 position = transform.position;
            position.x += Random.Range(-5f, 5f);
            position.z += Random.Range(-5f, 5f);
            var go = Instantiate(spawnObject, position, transform.rotation);
            Destroy(go, 4);
        }
    }
}
