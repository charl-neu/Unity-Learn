using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EventExample : MonoBehaviour
{
    public UnityEvent gameEvent;
    public UnityEvent<string> gameEventstring;

    public UnityAction gameAction;
    public EventSO startEvent;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            gameEvent?.Invoke();
        }

        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            gameEventstring?.Invoke("hi");
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            gameAction?.Invoke();
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            startEvent.RaiseEvent();
        }
    }
}
