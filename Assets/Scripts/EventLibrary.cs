using System;
using System.Collections;
using System.Collections.Generic;
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
    public List<Encounter> allEncounters;

    public List<Encounter> forestEncounters;
    public List<Encounter> plainsEncounters;
    public List<Encounter> riverEncounters;

    public List<Encounter> intervals;

    public Encounter HuntRestExplore;

    public Encounter Map;

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
                encounter = rnd.Next(0, allEncounters.Count);
                return allEncounters[encounter];
        }
        
        
    }

    private void TryInitialize()
    {
        if (!initialized)
        {
            initialized = true;
            allEvents = new Dictionary<string, Event>();
            allEncounters = new List<Encounter>();
            forestEncounters = new List<Encounter>();
            plainsEncounters = new List<Encounter>();
            riverEncounters = new List<Encounter>();
            intervals = new List<Encounter>();

            #region Map

            Map = new Encounter()
            {
                events = new Event()
                {
                    buttonText = "",
                    description = "Choose the next place to go",
                    image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                    event1 = new Event()
                    {
                        buttonText = "Forest",
                        description = "You chose the forest, click continue to begin.",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        continueIntruction = ContinueInstruction.GoToForestEncounter
                    },
                    event2 = new Event()
                    {
                        buttonText = "River",
                        description = "You chose the river, click continue to begin.",
                        image = Resources.Load<Sprite>("EventImages/BeeHive/beehive"),
                        continueIntruction = ContinueInstruction.GoToRiverEncounter
                    },
                    event3 = new Event()
                    {
                        buttonText = "Plains",
                        description = "You chose the plains, click continue to begin.",
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

            #endregion

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
