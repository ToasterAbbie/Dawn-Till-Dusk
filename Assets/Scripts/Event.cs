using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatChange
{
    addFood,
    minusFood,
    addWisdom,
    addOptimism
}

public class Event
{
    public Sprite image;
    public string description = " ";
    public string buttonText = " ";
    public StatChange[] statChange;

    public Event event1;
    public Event event2;
    public Event event3;
    public Event event4;
    public Event event5;

    public bool isLastEventInEncounter()
    {
        if (event1 == null &&
            event2 == null &&
            event3 == null &&
            event4 == null &&
            event5 == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Encounter
{
    public Event events;
}
