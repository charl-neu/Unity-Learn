using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Event", menuName = "Events/Event")]
public class EventBoolSO : ScriptableObject
{
    private UnityAction<bool> listeners;

    public void Subscribe(UnityAction<bool> listener) => listeners += listener;
    public void Unsubscribe(UnityAction<bool> listener) => listeners -= listener;
    public void RaiseEvent(bool value) => listeners?.Invoke(value);
}
