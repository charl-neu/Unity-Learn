using UnityEngine;

public class EventRecieverExample : MonoBehaviour
{
    public EventSO startEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var events = FindFirstObjectByType<EventExample>();
        events.gameAction += OnGameAction;


    }

    private void OnEnable()
    {
        startEvent.Subscribe(OnGameStart);
    }
    private void OnDisable()
    {
        startEvent.Unsubscribe(OnGameStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameEvent()
    {
        print("Game event");
    }

    public void OnGameEvent(string str)
    {
        print(str);
    }

    public void OnGameAction()
    {
        print("Game Action");
    }

    public void OnGameStart()
    {
        print("Game start!");
    }
}
