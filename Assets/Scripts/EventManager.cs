using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventState
{
    Encounter,
    HuntRestExplore,
    Interval,
    Map
}

public enum ContinueInstruction
{
    GoToForestEncounter,
    GoToPlainsEncounter,
    GoToRiverEncounter
}

public class EventManager : MonoBehaviour 
{

	public EventLibrary events;

    private EventState _state;

    private int currentInterval;

    public EventState State
    {
        get
        {
            return _state;
        }
    }

    private Encounter _currentEncounter;
    public Encounter CurrentEncounter
    {
        get
        {
            return _currentEncounter;
        }
        set
        {
            //TODO: Something needs to happen here to remove encounters already done. Not sure why this isn't working right now but cba to fix it at the moment.

            Encounter lastEvent = _currentEncounter;

            _currentEncounter = value;
            CurrentEvent = _currentEncounter.events;

            events.allEncounters.Remove(lastEvent);
        }
    }
    
    private Event _currentEvent;

    public Event CurrentEvent
    {
        get
        {
            return _currentEvent;
        }
        set
        {
            _currentEvent = value;
            UpdateStats();
        }
    }

    private int _food;

    public int Food
    {
        get
        {
            return _food;
        }
    }

    private int _wisdom;

    public int Wisdom
    {
        get
        {
            return _wisdom;
        }
    }

    void Start () 
	{
        _state = EventState.Map;
        _food = 5;
        _wisdom = 0;
        currentInterval = 0;
        events = GetComponent<EventLibrary>();
        CurrentEncounter = events.Map;
	}

	void Update () 
	{
		
	}

    public void Continue(ContinueInstruction? instruction)
    {
        switch (instruction)
        {
            case ContinueInstruction.GoToForestEncounter:
                _state = EventState.Encounter;
                CurrentEncounter = events.GetRandomEncounter(EncounterType.Forest);
                break;
            case ContinueInstruction.GoToPlainsEncounter:
                _state = EventState.Encounter;
                CurrentEncounter = events.GetRandomEncounter(EncounterType.Plains);
                break;
            case ContinueInstruction.GoToRiverEncounter:
                _state = EventState.Encounter;
                CurrentEncounter = events.GetRandomEncounter(EncounterType.River);
                break;
            default:
                switch (State)
                {
                    case EventState.Encounter:
                        _state = EventState.HuntRestExplore;
                        CurrentEncounter = events.HuntRestExplore;
                        break;
                    case EventState.HuntRestExplore:
                        _state = EventState.Interval;
                        CurrentEncounter = events.intervals[currentInterval];
                        break;
                    case EventState.Interval:
                        _state = EventState.Map;
                        currentInterval++;
                        CurrentEncounter = events.Map;
                        break;
                    case EventState.Map:
                        _state = EventState.Encounter;
                        CurrentEncounter = events.GetRandomEncounter();
                        break;
                    default:
                        break;
                }
                break;
        }

        
    }
    
    void UpdateStats()
    {
        StatChange[] changes = CurrentEvent.statChange;

        foreach (StatChange change in changes)
        {
            switch (change)
            {
                case StatChange.addFood:
                    _food++;
                    break;
                case StatChange.minusFood:
                    _food--;
                    break;
                case StatChange.addWisdom:
                    _wisdom++;
                    break;
                case StatChange.addOptimism:
                    _wisdom--;
                    break;
                default:
                    break;
            }
        }

        RunCaps();
    }

    void RunCaps()
    {
        if (_food > 5)
        {
            _food = 5;
        }
    }
}
