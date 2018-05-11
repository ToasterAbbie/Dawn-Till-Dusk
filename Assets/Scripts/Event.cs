using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatChange
{
    addFood,
    minusFood,
    addWisdom,
    addOptmism
}

public class Event
{
    public Sprite displayedImage, mainImage, leaderImage, childImage, hunterImage, dogImage, shamanImage;
	public string mainDescription, 
	lDescription, 
	cDescription, 
	hDescription, 
	dDescription, 
	sDescription, 
	bOneText, 
	bTwoText, 
	bThreeText, 
	bFourText, 
	bFiveText,
	bOneLinkedEvent,
	bTwoLinkedEvent,
	bThreeLinkedEvent,
	bFourLinkedEvent,
	bFiveLinkedEvent;
    public StatChange[] statChange;
}

public class Encounter
{
    public Dictionary<string, Event> Events;
}
