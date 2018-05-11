using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{

    private EventManager eventManager;

    private GameObject image,
                        description,
                        buttonOne,
                        buttonTwo,
                        buttonThree,
                        buttonFour,
                        buttonFive,
                        bTextOne,
                        bTextTwo,
                        bTextThree,
                        bTextFour,
                        bTextFive;

    private GameObject[] buttonTexts, buttons;

    public Sprite defaultButton;

    void Start()
    {
        image = GameObject.Find("EventImage");
        description = GameObject.Find("EventDescription");
        buttonOne = GameObject.Find("EventOptOne");
        buttonTwo = GameObject.Find("EventOptTwo");
        buttonThree = GameObject.Find("EventOptThree");
        buttonFour = GameObject.Find("EventOptFour");
        buttonFive = GameObject.Find("EventOptFive");
        bTextOne = GameObject.Find("EventTextOne");
        bTextTwo = GameObject.Find("EventTextTwo");
        bTextThree = GameObject.Find("EventTextThree");
        bTextFour = GameObject.Find("EventTextFour");
        bTextFive = GameObject.Find("EventTextFive");

        buttons = new GameObject[]
        {
            buttonOne,
            buttonTwo,
            buttonThree,
            buttonFour,
            buttonFive
        };

        buttonTexts = new GameObject[]
        {
            bTextOne,
            bTextTwo,
            bTextThree,
            bTextFour,
            bTextFive
        };

        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }

    void Update()
    {
        TurnShitBackOn();
        UpdateUIAccordingToEvent();
    }

    void ResetTexts()
    {
        description.GetComponent<Text>().text = " ";
        for (int i = 0; i < buttonTexts.Length; i++)
        {
            buttonTexts[i].GetComponent<Text>().text = " ";
        }
    }

    void UpdateUIAccordingToEvent()
    {
        ResetTexts();
        Event currentEvent = eventManager.events.allEvents[eventManager.CurrentEventName];
        image.GetComponent<Image>().sprite = currentEvent.displayedImage;
        description.GetComponent<Text>().text = currentEvent.mainDescription;
        bTextOne.GetComponent<Text>().text = currentEvent.bOneText;
        bTextTwo.GetComponent<Text>().text = currentEvent.bTwoText;
        bTextThree.GetComponent<Text>().text = currentEvent.bThreeText;
        bTextFour.GetComponent<Text>().text = currentEvent.bFourText;
        bTextFive.GetComponent<Text>().text = currentEvent.bFiveText;

        for (int i = 0; i < buttonTexts.Length; i++)
        {
            if (buttonTexts[i].GetComponent<Text>().text == " ")
            {
                buttons[i].GetComponent<Image>().enabled = false;
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void ButtonOneDo()
    {
        Event currentEvent = eventManager.events.allEvents[eventManager.CurrentEventName];
        eventManager.CurrentEventName = currentEvent.bOneLinkedEvent;
    }

    public void ButtonTwoDo()
    {
        Event currentEvent = eventManager.events.allEvents[eventManager.CurrentEventName];
        eventManager.CurrentEventName = currentEvent.bTwoLinkedEvent;
    }

    public void ButtonThreeDo()
    {
        Event currentEvent = eventManager.events.allEvents[eventManager.CurrentEventName];
        eventManager.CurrentEventName = currentEvent.bThreeLinkedEvent;
    }

    public void ButtonFourDo()
    {
        Event currentEvent = eventManager.events.allEvents[eventManager.CurrentEventName];
        eventManager.CurrentEventName = currentEvent.bFourLinkedEvent;
    }

    public void ButtonFiveDo()
    {
        Event currentEvent = eventManager.events.allEvents[eventManager.CurrentEventName];
        eventManager.CurrentEventName = currentEvent.bFiveLinkedEvent;
    }

    void TurnShitBackOn()
    {
        for (int i = 0; i < buttonTexts.Length; i++)
        {
            buttons[i].GetComponent<Image>().enabled = defaultButton;
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }
}
