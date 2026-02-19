using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Event", menuName = "Events/Event")]
public class EventFloatSO : ScriptableObject
{
    private UnityAction<float> listeners;

    public void Subscribe(UnityAction<float> listener) => listeners += listener;
    public void Unsubscribe(UnityAction<float> listener) => listeners -= listener;
    public void RaiseEvent(float value) => listeners?.Invoke(value);
}
