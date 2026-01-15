using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent triggerEvent;
    [SerializeField, TooltipAttribute("Tag of object to trigger event")] string triggerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            triggerEvent.Invoke();
        }
    }
}
