using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventState
{
    Prologue,
    Encounter,
    HuntRestExplore,
    Interval,
    Map,
    Ending
}

public enum ContinueInstruction
{
    GoToForestEncounter,
    GoToPlainsEncounter,
    GoToRiverEncounter,
    Restart
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
            events.RemoveEncounter(_currentEncounter);
            _currentEncounter = value;
            CurrentEvent = _currentEncounter.events;
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
        Setup();
	}

    void Setup()
    {
        _state = EventState.Prologue;
        _food = 0;
        _wisdom = 0;
        currentInterval = 0;
        events = GetComponent<EventLibrary>();
        CurrentEncounter = events.Prologue;
    }

	void Update () 
	{
        if (_state != EventState.Ending)
        {
            if (_food < 0)
            {
                _state = EventState.Ending;
                CurrentEncounter = events.MinFood;
            }
            else if (_wisdom <= -5)
            {
                _state = EventState.Ending;
                CurrentEncounter = events.MaxOptimism;
            }
            else if (_wisdom >= 5)
            {
                _state = EventState.Ending;
                CurrentEncounter = events.MaxWisdom;
            }
            else if (currentInterval >= 9)
            {
                if (_wisdom > 0)
                {
                    _state = EventState.Ending;
                    CurrentEncounter = events.Wisdom;
                }
                else if (_wisdom < 0)
                {
                    _state = EventState.Ending;
                    CurrentEncounter = events.Optimism;
                }
                else if (_wisdom == 0)
                {
                    _state = EventState.Ending;
                    CurrentEncounter = events.Balanced;
                }
            }
        }
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
            case ContinueInstruction.Restart:
                Setup();
                break;
            default:
                switch (State)
                {
                    case EventState.Prologue:
                        _state = EventState.Map;
                        CurrentEncounter = events.Map;
                        break;
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
                    case EventState.Ending:
                        Setup();
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

        if (changes != null && changes.Length > 0)
        {
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
