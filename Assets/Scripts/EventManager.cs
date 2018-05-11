using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour 
{

	public EventLibrary events;

    private string _currentEventName;

	public string CurrentEventName {
        get
        {
            return _currentEventName;
        }
        set
        {
            _currentEventName = value;
            currentEvent = events.allEvents[value];
        }
    };
    public Event currentEvent;

    private int _food;

    public int Food
    {
        get
        {
            return _food;
        }
    }

	void Start () 
	{
        _food = 5;
        events = GetComponent<EventLibrary> ();
		CurrentEventName = "bHiveInit";
	}

	void Update () 
	{
		
	}
    
    void UpdateStats()
    {
        StatChange[] changes = currentEvent.statChange;

        foreach (StatChange change in changes)
        {
            switch (change)
            {
                case StatChange.addFood:
                    break;
                case StatChange.minusFood:
                    break;
                case StatChange.addWisdom:
                    break;
                case StatChange.addOptmism:
                    break;
                default:
                    break;
            }
        }
    }
}
