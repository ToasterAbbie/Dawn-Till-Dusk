using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EncounterType
{
    Forest,
    Plains,
    River
}

public class EventLibrary : MonoBehaviour
{

    public Dictionary<string, Event> allEvents;
    
    public List<Encounter> forestEncounters;
    public List<Encounter> plainsEncounters;
    public List<Encounter> riverEncounters;

    public List<Encounter> intervals;

    public Encounter HuntRestExplore;
    public Encounter Map;
    public Encounter Prologue;

    public Encounter MinFood;
    public Encounter MaxWisdom;
    public Encounter MaxOptimism;
    public Encounter Wisdom;
    public Encounter Optimism;
    public Encounter Balanced;

    private bool initialized = false;

    public Encounter GetRandomEncounter(EncounterType? type = null)
    {
        TryInitialize();

        System.Random rnd = new System.Random();
        int encounter;

        switch (type)
        {
            case EncounterType.Forest:
                encounter = rnd.Next(0, forestEncounters.Count);
                return forestEncounters[encounter];
            case EncounterType.Plains:
                encounter = rnd.Next(0, plainsEncounters.Count);
                return plainsEncounters[encounter];
            case EncounterType.River:
                encounter = rnd.Next(0, riverEncounters.Count);
                return riverEncounters[encounter];
            default:
                encounter = rnd.Next(0, AllEncounters().Count);
                return AllEncounters()[encounter];
        }
        
        
    }

    public void RemoveEncounter(Encounter encounter)
    {
        if (forestEncounters.Contains(encounter))
        {
            forestEncounters.Remove(encounter);
        }
        if (plainsEncounters.Contains(encounter))
        {
            plainsEncounters.Remove(encounter);
        }
        if (riverEncounters.Contains(encounter))
        {
            riverEncounters.Remove(encounter);
        }
    }

    private List<Encounter> AllEncounters()
    {
        return forestEncounters.Concat(plainsEncounters).Concat(riverEncounters).ToList();
    }

    private void TryInitialize()
    {
        if (!initialized)
        {
            initialized = true;
            allEvents = new Dictionary<string, Event>();
            forestEncounters = new List<Encounter>();
            plainsEncounters = new List<Encounter>();
            riverEncounters = new List<Encounter>();
            intervals = new List<Encounter>();
            
            #region Prologue

            Prologue = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Would you like to play the damn game mmk?",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    event1 = new Event()
                    {
                        buttonText = "Start",
                        description = "Prologue 1",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Continue",
                            description = "Prologue 2",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            event1 = new Event()
                            {
                                buttonText = "Continue",
                                description = "Prologue 3",
                                image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                                event1 = new Event()
                                {
                                    buttonText = "Continue",
                                    description = "Prologue 4",
                                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                                    continueText = "Begin!"
                                }
                            }
                        }
                    }
                }
            };

            #endregion

            #region Map

            Map = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Where should the Humans go?",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    isContinueScreen = true,
                    event1 = new Event()
                    {
                        buttonText = "Forest",
                        description = "The Humans head into the Forest",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        continueIntruction = ContinueInstruction.GoToForestEncounter
                    },
                    event2 = new Event()
                    {
                        buttonText = "River",
                        description = "The Humans head to the River",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        continueIntruction = ContinueInstruction.GoToRiverEncounter
                    },
                    event3 = new Event()
                    {
                        buttonText = "Plains",
                        description = "The Humans head to the Plains",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        continueIntruction = ContinueInstruction.GoToPlainsEncounter
                    }
                }
            };

            #endregion

            #region Intervals

            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Shaman tries to persuade her fellow humans that the gods exist, to no avail. They laugh heartily at her. The Dog barks. There is something in his eyes that makes the Shaman believe that he understands her.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Goddess of the Dawn gives the Child a vision. The Child, who has not yet learned to speak, takes a nap with the Dog. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Leader wants to try out a new form of communication in which people share their life achievements and images of cats in one contained space. The Shaman is excited to show her friends cave paintings of the Child and express how proud she is. The Dog is excited, also. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Hunter draws a detailed map of how to get to Big Pointy Rock, but is overcome by social anxiety and fails to tell the others. The group decides to follow the Dog instead. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Shaman stumbles upon a perfectly rounded, clear glass orb. When she reaches out and touches it, her eyes cloud over and she falls into a trance in which she reveals all the secrets of the universe to the other humans. Unfortunately, she is speaking entirely in French. The Dog barks. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Hunter longs to interact with his fellow humans. He tells a joke. No one laughs. The Dog comforts the Hunter as he cries himself to sleep. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Child says his first words! They are: 'Don’t forget to like and subscribe!' The Dog walks away. When he returns – after some time – the sparkle in his eyes has dimmed a little.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Leader pitches the idea of a democratic government to the group. The group, not able to comprehend the words “democratic” or “government”, stare blankly at him. The Dog hangs his head in shame.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });
            intervals.Add(new Encounter()
            {
                events = new Event()
                {
                    description = "The Hunter wakes up in a cold sweat after a nightmare involving being attacked by the angry spirits of all the animals he’s killed. He makes a vow to be a vegan henceforth. The Dog rolls his eyes.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                }
            });

            #endregion

            #region Hunt Rest Explore

            HuntRestExplore = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Hunt, Rest or Explore?",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    event1 = new Event()
                    {
                        buttonText = "Hunt",
                        description = "The Hunter disappears for a while and comes back with a variety of dead animals. The group has a hearty meal. (+food)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addFood },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Rest",
                        description = "The humans have a lie down. They feel incredibly rejuvinated. (+optimism)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addOptimism }
                    },
                    event3 = new Event()
                    {
                        buttonText = "Explore",
                        description = "The group explore the immediate area, learning many things from their surroundings. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            };

            #endregion

            #region Encounters

            #region Forest
            forestEncounters.Add(new Encounter()
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
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter launches a spear at the hive, and it drops to the ground, cloven perfectly in two. The bees bow to the Hunter’s expertise, and name him their Queen. (++food + optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addOptimism }
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
                            statChange = new StatChange[] { StatChange.addOptimism }
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

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Dark, brooding clouds gather. Lightning splits from the sky above and ignites one of the trees into a pillar of fire.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Play with the fire",
                        description = "Play with the fire.",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader stretches out his fingers towards the dancing flames, only to have his hand badly burnt. The Shaman, most put out, tends to his wounds as he weeps softly into his unburnt palm. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter shoots a squirrel from a nearby tree and roasts it over the fire until it is golden brown. All of the humans agree it is delicious, but the Shaman thinks it needs some seasoning.(+food + wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child knows not to play with fire. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog urinates on the fire and puts it out with great efficiency. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Pray to the fire",
                        description = "The Shaman bows down and prays into the fire. The fire dances majestically in a way that implies it’s trying to communicate. No one understands what the fire is saying. (+optimism)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addOptimism }
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The Child is horribly bored and demands to play hide and seek.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Play with the Child",
                        description = "Play with the Child",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader seeks a hiding place in the nearest bush he can find, unwilling to exert much energy. Unbeknownst to him, the bush is full of stinging nettles. He is itchy for the next hour. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter vanishes in a flash and cannot be found until the Child eventually gives up. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman creates a disguise from nearby foliage, blending her perfectly with her surroundings. The is not found for some time. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog does not comprehend the concept of hide and seek, but somehow comes out of the experience with many belly rubs. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    },
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A long, sturdy-looking vine trails from the branch of a tree.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Swing on the vine",
                        description = "Swing on the vine",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter swings on the vine, screaming like Tarzan. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child has a truly fantastic time swinging on the vine. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Climb the vine",
                        description = "Climb the vine",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader attempts to hoist himself up using the vine, but alas, he has no upper-body strength.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event2 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman skilfully scales the vine to find a nest of eggs admits the branches. (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        }
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The group encounter a Dire wolf. Mesmerised by its beauty, they stare at it in wonder.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Aproach the Dire wolf",
                        description = "Aproach the Dire wolf",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader approaches the wolf “Chris Pratt Jurassic World” style. The wolf decides that it doesn’t like the Leader. Long story short, the group end up running away screaming. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter sources the nearest stick and flings it far into the forest. The Dire wolf runs away, never to return. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child approaches the wolf “Chris Pratt Jurassic World” style. Turns out the wolf is a good boy. Many tummy rubs ensue. (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog, sensing the similarities between the two animals, befriends the wolf, who, pleased to have a new buddy, leads the Dog to a secret stash of meat.  (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman is more of a cat person, and the wolf knows it. The group runs away. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Flee",
                        description = "Not knowing what the Dire wolf is or what bizarre universe it originated from, the group decide to leave it well enough alone. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Before the group is an enormous tree towering into the sky. Its boughs could conceal many a bountiful reward.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Climb the tree",
                        description = "Climb the tree",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader is hit with a terrible case of vertigo and refuses to climb the tree.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter skilfully scales the tree. Among the branches he finds a plethora of fresh fruit.  (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child, barely standing three feet off the ground, grabs the nearest branch and pulls it down with all the might his tiny body can muster. But his efforts are not enough, and the branch springs back out of his hands, catapulting and unsuspecting squirrel into the stratosphere. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "Dogs can’t climb trees, silly. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman composes a beautiful and thoughtful prayer to the tree gods. Unfortunately, there aren’t any tree gods. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Look! A pile of sticks!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Create something",
                        description = "Create something",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader adds one final stick to the pitiful hut he has crafted. It collapses. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter builds a 5-storey mansion out of the sticks, pool and gym included. He leases it to a squirrel for a handful of nuts. (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child crafts a wooden pickaxe from the sticks and begins mining for diamonds. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog has a great time playing with the sticks. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman makes a series of creepy voodoo people. She swears she isn’t a witch.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive")
                        }
                    },
                }
                    
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The group come across a patch of mushrooms speckled with purple and red spots. They smell… interesting.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Pick the mushrooms",
                        description = "Pick the mushrooms",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader thoughtlessly shoves an entire mushroom into his mouth. His eyes instantly glaze over, and with foam bubbling at his lips, he collapses to the ground. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter cautiously graces a mushroom with a touch of his tongue. He dances ferociously and majestically for a long time afterwards. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child knows to say no to drugs. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog eats a mushroom and is immediately sick in a bush. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman harvests the mushrooms and cooks them into a delicious soup. When it comes to cooking, the Shaman doesn’t have mushroom for improvement. (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Leave the mushrooms",
                        description = "Smart choice. Just because they smell interesting doesn’t mean they’ll be good in your tum. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "An injured deer lies in the group’s path. The fear it’s exuding is palpable.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Kill the deer",
                        description = "The Hunter puts the deer quickly out of its misery. The group cooks and carves it. Delicious. (+food)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addFood },
                        
                    },
                    event2 = new Event()
                    {
                        buttonText = "Spare the deer",
                        description = "Spare the deer",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader breaks down, sinks to his knees and sobs into his hands. Nothing is achieved through this.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child stretches out his hand and pats the deer on its head. Suddenly, the deer is healed! (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog lies down next to the deer. Aww. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman uses the surrounding resources to concoct a potion that cures the deer of all its ails. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The group come across some birds and bees.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Inspect the birds and the bees",
                        description = "Inspect the birds and the bees",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader stares ahead, clueless. He asks what’s going on. The Child explains through a series of detailed diagrams. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter remembers that he needs to delete his internet history. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Shaman gasps and covers the Child’s eyes. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman gasps and covers the Child’s eyes. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog barks persistently at the shocking encounter until all offending parties fly away. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        }
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "An enormous pile of leaves blocks the path!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Jump in!",
                        description = "Jump in!",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter jumps into the pile and discovers 3 mice have made their home in it. Upon close inspection, he determines that they are blind. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child and the Dog frolic around in the leaves with gay abandon. A great time is had. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Child and the Dog frolic around in the leaves with gay abandon. A great time is had. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman makes a dress out of the leaves. It doesn’t leaf much to the imagination. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Leaf the leaves alone",
                        description = "The Leader asserts that he is too old and mature to play in the leaves. He leafs them alone. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            });

            forestEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A sleeping bear lies mere feet off the path that the group are following. It’s snoring soundly.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Sneak past the bear",
                        description = "Sneak past the bear",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child takes a single step in the bear’s direction. As if sensing danger, the bear’s eyes open, fully alert and full of terror. Upon seeing the child, it flees with a blood-curdling scream. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog, in his infinite wisdom, leads the group quietly around the bear. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader brandishes a stick and pokes the bear. This is not a good idea. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Kill the bear",
                        description = "The Hunter does a stealthy combat roll towards the bear and kills it with a single slash of his sword. The group pass by safely. (+food +wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom }
                    }
                }
            });

            #endregion

            #region Plains


            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "All of a sudden, the Dog darts off over a hill.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Follow the Dog",
                        description = "The Dog leads the group to a peep of chickens. Nuggets for everyone! (++food + wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addWisdom }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Call the Dog back",
                        description = "The Dog returns, somewhat sheepishly, with a dead chicken in its mouth. There is an adequate quantity of nuggets to share between the group. (+food +optimism)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The group spot some snakes on the plains!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Get the reference",
                        description = "The Leader yells “I’ve had it with these motherheckin’ snakes on these motherheckin’ planes!” (+optimism)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addOptimism }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Don't get the reference",
                        description = "Don't get the reference",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child screams and runs. The group follows.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "Snakes. It had to be snakes. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman pulls out her Black Mambarine and attempts to charm the snakes. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The group wade through a patch of tall grass. They encounter a pigeon! ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Attack!",
                        description = "Attack!",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader is confused! He hurts himself in his confusion!",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive")
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter uses spear! It’s super effective! (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom },
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child catches the pigeon! There is no room in your party. Pigeon is sent to your PC. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog uses Bark! The pigeon flees. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "What? Shaman is evolving… Congratulations! Shaman evolved into Shamander! (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Flee",
                        description = "The group flee from the ferocious bird. They get away safely. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "As the group progress, they spot an oddly shaped rock on the plains that doesn’t resemble any other they have encountered on this planet. They approach, and find it to resemble the meteor they emerged from, split in half.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Investigate the meteor",
                        description = "Investigate the meteor",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader searches inside the meteor. He finds a note written in a strange script that he doesn’t understand. What could it mean… (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter searches the surrounding area and comes across a set of footprints. They seem to lead towards Big Pointy Rock… (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child climbs inside the meteor to search its interior. He finds a small toy seems suitable for a child his age. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog begins barking frantically, almost as though he’s trying to explain something to the group. Alas, they do not speak Dog, and cannot understand him. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Pray to the meteor",
                        description = "The Shaman drops to her knees and says a prayer to every god she believes in, desperately trying to glean meaning from the meteor. The Dog barks at her. (+optimism)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addOptimism },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "As he walks, the Child carelessly trips over a rock on the ground. He collapses and subsequently bursts into tears. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Comfort the Child",
                        description = "Comfort the Child",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "On his way to cheer up the Child, the Leader falls over the same rock. He faceplants the grass. The Child is amused. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter pats the Child on the head with one of his big, strong hands. This helps a lot. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog licks away the Child’s tears. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event4 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman bends down and gives the Child a cuddle. There is nothing better than a cuddle from your mum. (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Ignore the Child",
                        description = "Through his relentless and heaving sobs, the Child realises that no one is going to help him. He learns a valuable lesson, realising he needs to be self-sufficient to survive this cruel, cruel world, that there is no one he can rely on to be there in his darkest hour – not even his own family. From now on, he knows that the only sure thing in his life is himself, and that he must work hard every day to be independent and brave, for there are none out there who will hold his hand through his hardships. He clenches his jaw and balls his fists, rising to his feet with barely a wobble, despite the graze on his knee. He wipes salty tears from his cheeks. He is a man now. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The Dog finds a stick in the grass. Wagging his tail, he bounds to the group and drops it at their feet, looking up at them expectantly.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Play fetch with the Dog",
                        description = "Play fetch with the Dog",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter picks up the stick and hurls it so far into the distance that the Dog decides he doesn’t want to play anymore. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "While the Child lacks significant upper-body strength and therefore can’t throw the stick particularly far, they both have a really great time. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event3 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman launches the stick over the closest hill. The Dog returns with a rabbit. (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Ignore the Dog",
                        description = "The Leader is far too “busy” for trifle games such as fetch. The Dog shall have to play by himself. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A wonderfully round, reasonably large hill stands before them. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Roll down the hill",
                        description = "Roll down the hill",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child rolls down the hill and has a great time! (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader trips over his own feet and plummets head-over-heels down the hill. The Child finds this hill-arious. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog rolls down the hill, and is completely green when he reaches the bottom. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Walk over the hill",
                        description = "Walk over the hill",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Shaman warns the group that they will have to wash the grass stains from their clothes themselves if they make the decision to roll down the hill. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter thinks he spies a blue hedgehog in the green hills… (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A lone apple tree stands in the middle of the plains.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Eat an apple",
                        description = "Eat an apple",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader plucks an apple from its branch and takes a bite. Suddenly his mind is flooded with knowledge of the Goddess of the Dawn and the God of the Dusk. He keeps this knowledge to himself. (++wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom, StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter is more of an Android guy.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child isn’t tall enough to reach any of the apples.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event4 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman plucks an apple from its branch and takes a bite. Suddenly her mind is flooded with knowledge of the Goddess of the Dawn and the God of the Dusk. She shares this knowledge with the group. (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Leave the tree alone",
                        description = "The Dog growls at anyone that tries to go near the tree.",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A wild, majestic horse is spotted among the grass.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Ride the horse",
                        description = "Ride the horse",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The group watch as the Leader fails to even mount the horse. Awkward!",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter majestically leaps into the horse’s back and gallops off into the sunset, unaware of what a sunset it or how it works. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Shaman lifts the Child onto the horse and together, horse and Child complete a round of dressage. It’s a 10 from me. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Kill the horse",
                        description = "The group watch in awe and terror as the Shaman mercilessly kills the horse, turns it into burgers and sells it to Tesco. (+food +wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The group encounter a patch of brightly coloured wild flowers grown amongst blades of grass.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Pick the flowers",
                        description = "Pick the flowers",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman picks the flowers and uses them in a peculiar potion. It does absolutely nothing, but she has a good time making it. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child gives a bunch of flowers to the Shaman as a gift. There is good in this world! (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Smell the flowers",
                        description = "Smell the flowers",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader sniffs the patch of flowers and immediately starts sneezing. Congratulations! You have discovered hay fever! (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter takes a long, deep inhale through the nostrils to smell the sweetest smell ever smelt. He picks the flowers and makes his own perfume called The Oldest Spice. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism },
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The group watch as the Dog walks over to sniff the flowers. He eats them instead. (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom },
                        },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Oh, look! A chicken!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Pluck a feather from the chicken",
                        description = "Pluck a feather from the chicken",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman plucks a feather from the chicken’s back and uses it in conjunction with a conveniently present bottle of ink to write something down. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child uses a feather to tickle the Dog. The Dog is unamused, but the Child is. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Collect one of the chicken's eggs",
                        description = "Collect one of the chicken's eggs",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader attempts to cook up some scrambled eggs on a rock baking in the sun. Gordon Ramsay would have some words to say about it. (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter leans in close to the eggs and notices one of them is decorated with bright, coloured patterns. One might call it an Easter egg… (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism },
                        },
                    }
                }
            });

            plainsEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The humans hear an odd sound that could be described onomatopoeically as a “moo” coming from over the next hill. They investigate to discover a cow.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Milk the cow",
                        description = "Milk the cow",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The cow is clearly not comfortable with this. (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom },
                        },
                        event2 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman milks the cow and produces a refreshing pint of milk. If only cookies had been invented! (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism },
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Collect one of the chicken's eggs",
                        description = "Collect one of the chicken's eggs",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter takes down the cow with his spear and whips up some tasty burgers. The group are lovin’ it. (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism },
                        },
                    }
                }
            });

            #endregion

            #region River

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The pathway on the side of the river the group are currently walking on is too muddy. They need to cross the river.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Make a raft",
                        description = "Make a raft",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader places the Hunter face down in the water and gestures frantically for the rest of the group to climb aboard. To cut a long story short, they end up swimming. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter attempts to ride a duck across the river. Sadly, the duck doesn’t survive the journey, but the good news is that the group has duck pancakes for lunch. (+food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child climbs up onto the Dog’s back, and together they paddle safely to the shore across the river. The rest of the group follow, but it’s far less adorable. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Child climbs up onto the Dog’s back, and together they paddle safely to the shore across the river. The rest of the group follow, but it’s far less adorable. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman bundles together an enormous quantity of nearby sticks and leaves. Remarkably, it floats! The whole group clamber aboard and float to the other side without a single hiccup. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Swim",
                        description = "Despite never having encountered water before, it takes surprisingly little time for them to learn how to swim. The journey across is relatively painless. (+optimism)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addOptimism }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Under the surface of the water, something moves. Upon closer inspection, the group discover it’s a school of fish! ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Catch some fish",
                        description = "Catch some fish",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader attempts to catch a fish in order to impress the Shaman. He plummets head first into the river. The Shaman comforts him, assuring him there are plenty more fish in the sea. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter skewers 5 fish wish a singular throw of his spear. (++food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child jumps into the water and emerges with a single fish in hand. The group beam with pride. (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog leaps into the river and scares away all the fish.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman weaves a net from nearby reeds and catches a plethora of fish. (++food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addWisdom }
                        }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A paddling of ducks bobs along on the river’s surface.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Investigate the ducks",
                        description = "Investigate the ducks",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child peers at the paddling and notices a still, smaller, yellow duck amongst the others. As he reaches out to grab it, it vanishes, almost as if it was an Easter egg in a video game… (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman quacks at the ducks. They do not quack back. She learns that she cannot speak Duck. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Hunt the ducks",
                        description = "Hunt the ducks",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter attempts to hook the ducks with a fishing rod. He muses to himself: could this be turned into some kind of game? (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog hides in the reeds, then swipes up a single duck and stands in a pose that’s oddly familiar… (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Under the surface of the water, something moves. Upon closer inspection, the group discover it’s a school of fish! ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Catch some fish",
                        description = "Catch some fish",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader attempts to catch a fish in order to impress the Shaman. He plummets head first into the river. The Shaman comforts him, assuring him there are plenty more fish in the sea. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter skewers 5 fish wish a singular throw of his spear. (++food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child jumps into the water and emerges with a single fish in hand. The group beam with pride. (+food +optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog leaps into the river and scares away all the fish.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman weaves a net from nearby reeds and catches a plethora of fish. (++food +wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood, StatChange.addFood, StatChange.addWisdom }
                        }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A shiny object is spotted under the water!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Pick it up",
                        description = "Pick it up",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader finds a golden nugget and keeps it to himself.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter is mesmerised by the shiny object. It takes all the Dog’s strength to pull him away from the water’s edge. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child reaches deep into the riverbed to find a stash of gold. He shares it with the rest of the group. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog learns how to dig in the river. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "Upon retrieving the shiny object, the Shaman uses it in a ritual for an unknown purpose. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Something stinks.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Wash people in the river",
                        description = "Wash people in the river",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter strips down to reveal a perfect, sculpted body. The Dog and the Shaman blush. (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader splashes water on his armpits. The smell persists.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog washes himself, and when he emerges from the river he shakes himself off and sprays everyone with water. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Shaman washes the child thoroughly behind the ears. Remarkably, the smell is completely gone. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman washes the child thoroughly behind the ears. Remarkably, the smell is completely gone. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        }
                    },
                    event2 = new Event()
                    {
                        buttonText = "Wash clothes in the river",
                        description = "The group strip down and wash their clothes in the river. The stink is slightly less acrid than before. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The Leader sinks into quicksand!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Help the Leader",
                        description = "Help the Leader",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter uses his brute strength to wrench the Leader free of the quicksand. The Leader drops to his knees and pledges his soul to the Hunter. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman crafts a rope from nearby reeds and fishes the Leader out. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog heroically dives into the quicksand. The group watch, jaws dropped, hearts in their mouths, as moments tick by excruciatingly slowly. At last! The Dog emerges from the quicksand, the Leader slung across his back! (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Leave him be",
                        description = "The Child watches in amusement as the Leader claws his way out of the quicksand, inch by hilarious inch. (+wisdom)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addWisdom }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A frog leaps across the path of the humans.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Interact with the frog",
                        description = "Interact with the frog",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter, enamoured with the frog, keeps it in his pocket and names it Pepe. He has finally made a friend. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader picks up the frog and licks it. He spends the next ten minutes writhing on the floor, mumbling incoherently whilst foaming from the mouth. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman kisses the frog. Nothing happens. She vows to keep kissing frogs until she finds her prince. She turns to find the Leader clad in a frog costume. She sighs. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child gives the frog a blueberry. He loves it! (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event5 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog eats the frog. Gross. (+food)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addFood }
                        }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Oh no! The Child has fallen in the river!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Save the Child",
                        description = "Save the Child",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader tries to save the Child, but falls in as well. The Dog saves them both. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter tosses in a nearby branch for the Child to hold onto. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog swims over and drags the Child, shivering and sodden, to safety. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event4 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman gains the power of Motherly Protection, and dives in to save the day. (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Don't save the Child",
                        description = "The Child learns to swim, because he is a strong, independent child who don’t need no parent/guardian. (++optimism)",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "A fallen tree lies across the river, creating a makeshift bridge. The group decide to play Pooh sticks.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Who wins?",
                        description = "Who wins?",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter drops an enormous log into the river and is immediately disqualified. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog leaps into the water and snatches up the Leader’s stick. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Shaman is very disappointed with the performance of the Leader’s stick.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event4 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman’s stick gets caught in the river reeds.",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        },
                        event5 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child tosses in a stick that is far superior to everyone else’s, and it zooms down the river to win the game. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        }
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The river drops away into a roaring waterfall. ",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Dive down the waterfall",
                        description = "Dive down the waterfall",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter completes at least 5 somersaults in the air before cutting into the water with barely a ripple. It’s a 10 from me. (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader slips on a wet stone and ends up belly flopping onto the surface of the water. That’s gonna hurt tomorrow. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Dog takes a joyful and majestic leap off the top and splashes into the water below. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Climb down the waterfall",
                        description = "Climb down the waterfall",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman asserts that diving off the waterfall is too dangerous and scales down the side instead. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child finds a slippery slope to slide down to safety. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "As they near the water’s edge, the group notice five faces staring back at them from the surface. It’s their reflections!",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Stare at reflection",
                        description = "Stare at reflection",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter stares deeply into the eyes of his reflection. He has finally found someone he can connect with. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman thinks she is lookin’ hella fine. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader stares into the water. He starts feeling self-conscious about his weight. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Splash!",
                        description = "Splash!",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child and the Dog are both confused as to who exactly it is that is staring back at them. They attack them ferociously only to discover it’s just water. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Dog",
                            description = "The Child and the Dog are both confused as to who exactly it is that is staring back at them. They attack them ferociously only to discover it’s just water. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                    }
                }
            });

            riverEncounters.Add(new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "The group find a nice collection of smooth stones by the waters edge, perfect for skimming the water with.",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    statChange = new StatChange[] { StatChange.minusFood },
                    event1 = new Event()
                    {
                        buttonText = "Skim the stones",
                        description = "Skim the stones",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Hunter",
                            description = "The Hunter throws the rock with such astonishing elegance that the stone bounces downstream and completely out of sight. (++optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism, StatChange.addOptimism }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Shaman",
                            description = "The Shaman gets a good few bounces with the stone before it plops into the water and sinks to the river floor. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                    },
                    event2 = new Event()
                    {
                        buttonText = "Splash!",
                        description = "Splash!",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        event1 = new Event()
                        {
                            buttonText = "Leader",
                            description = "The Leader’s stone bounces a total of one time before it sinks. He discovers that he is not a natural at this. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                        event2 = new Event()
                        {
                            buttonText = "Child",
                            description = "The Child lobs a stone into the river, and before it even has the chance to bounce, the Dog leaps in after it. (+optimism)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addOptimism }
                        },
                        event3 = new Event()
                        {
                            buttonText = "Dog",
                            description = "Dogs don’t do throwing. Only catching. (+wisdom)",
                            image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                            statChange = new StatChange[] { StatChange.addWisdom }
                        },
                    }
                }
            });


            #endregion

            #endregion

            #region Endings

            string endingPhrase = "Play again";
            MinFood = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "You died of food",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    continueIntruction = ContinueInstruction.Restart,
                    continueText = endingPhrase
                }
            };

            MaxWisdom = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "You died of too much Wisdom",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    continueIntruction = ContinueInstruction.Restart,
                    continueText = endingPhrase
                }
            };

            MaxOptimism = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "You died of too much Optmism",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    continueIntruction = ContinueInstruction.Restart,
                    continueText = endingPhrase
                }
            };

            Optimism = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "You died of Optimism",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    continueIntruction = ContinueInstruction.Restart,
                    continueText = endingPhrase
                }
            };

            Wisdom = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "You died of Widsom",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    continueIntruction = ContinueInstruction.Restart,
                    continueText = endingPhrase
                }
            };

            Balanced = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "You died of Nothing",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    continueIntruction = ContinueInstruction.Restart,
                    continueText = endingPhrase
                }
            };

            #endregion
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
