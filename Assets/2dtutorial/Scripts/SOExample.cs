using UnityEngine;
using UnityEngine.InputSystem;

public class SOExample : MonoBehaviour
{
    [SerializeField] IntData score;

    private void Start()
    {
        score.value = 0;
    }


    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            score.value += 100;
        }
    }

}
