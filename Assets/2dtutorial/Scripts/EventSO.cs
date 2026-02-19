using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Event", menuName = "Events/Event")]
public class EventSO : ScriptableObject
{
    private UnityAction listeners;

    public void Subscribe(UnityAction listener) => listeners += listener;
    public void Unsubscribe(UnityAction listener) => listeners -= listener;
    public void RaiseEvent() => listeners?.Invoke();
}
