using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLibrary : MonoBehaviour
{

    public Dictionary<string, Event> allEvents;
    public List<Encounter> allEncounters;

    public List<Encounter> intervals;

    public Encounter HuntRestExplore;

    private bool initialized = false;

    public Encounter GetRandomEncounter()
    {
        TryInitialize();

        System.Random rnd = new System.Random();

        int encounter = rnd.Next(0, allEncounters.Count);
        
        return allEncounters[encounter];
    }

    private void TryInitialize()
    {
        if (!initialized)
        {
            initialized = true;
            allEvents = new Dictionary<string, Event>();
            allEncounters = new List<Encounter>();
            intervals = new List<Encounter>();

            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 1",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 2",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 3",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 4",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 5",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 6",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 7",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 8",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "Some shit happens 9",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });

            HuntRestExplore = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Hunt / Rest / Explore?",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    event1 = new Event()
                    {
                        buttonText = "Hunt",
                        description = "You went hunting and shit",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addFood },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Rest",
                        description = "You rested and shit",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addOptmism }
                    },
                    event3 = new Event()
                    {
                        buttonText = "Explore",
                        description = "You explored and shit",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            };

            allEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The humans spot a beehive high up in the branches of a tree, a delectable golden liquid dripping from within it.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Harvest",
                        description = "Harvest.",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader picks up the Child and hurls him at the beehive, effectively knocking it from its branch. The bees, alarmed by this gross display of recklessness, flee from their hive. The Child, only slightly bruised, picks up the empty hive and harvests the honey from within. (+food + optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptmism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter launches a spear at the hive, and it drops to the ground, cloven perfectly in two. The bees bow to the Hunter’s expertise, and name him their Queen. (++food + optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addOptmism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child climbs the tree and knocks the hive from its branch. It crashes to the ground, and a swarm of enraged bees sting the group, much to the Child’s amusement. Turns out bees sting. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog barks continuously at the hive, to no avail. The group applaud his efforts. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptmism }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman attempts to charm the bees away from the hive with a crudely crafted ukulebee. It ends badly. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Leave",
                        description = "The group wisely decide to leave the beehive alone, and trudge off having never known the taste of honey. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            });

            allEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "THE SECOND ONE",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Harvest2",
                        description = "Harvest.",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader2",
                            description = "The Leader picks up the Child and hurls him at the beehive, effectively knocking it from its branch. The bees, alarmed by this gross display of recklessness, flee from their hive. The Child, only slightly bruised, picks up the empty hive and harvests the honey from within. (+food + optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptmism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter2",
                            description = "The Hunter launches a spear at the hive, and it drops to the ground, cloven perfectly in two. The bees bow to the Hunter’s expertise, and name him their Queen. (++food + optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addOptmism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child2",
                            description = "The Child climbs the tree and knocks the hive from its branch. It crashes to the ground, and a swarm of enraged bees sting the group, much to the Child’s amusement. Turns out bees sting. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog2",
                            description = "The Dog barks continuously at the hive, to no avail. The group applaud his efforts. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptmism }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman2",
                            description = "The Shaman attempts to charm the bees away from the hive with a crudely crafted ukulebee. It ends badly. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Leave2",
                        description = "The group wisely decide to leave the beehive alone, and trudge off having never known the taste of honey. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            });
        }
    }

    void Awake()
    {
        TryInitialize();
    }


    void Update()
    {

    }
}
