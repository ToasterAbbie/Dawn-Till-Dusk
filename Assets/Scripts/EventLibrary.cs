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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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

            allEncounters.Add(new Encounter()
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
