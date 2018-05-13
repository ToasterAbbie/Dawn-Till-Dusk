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
                        button1Text,
                        button2Text,
                        button3Text,
                        button4Text,
                        button5Text,
                        foodLevel,
                        wisdomLevel,
                        continueButton,
                        continueButtonText;

    private GameObject[] buttonTexts, buttons, statTexts;

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

        button1Text = GameObject.Find("EventTextOne");
        button2Text = GameObject.Find("EventTextTwo");
        button3Text = GameObject.Find("EventTextThree");
        button4Text = GameObject.Find("EventTextFour");
        button5Text = GameObject.Find("EventTextFive");

        foodLevel = GameObject.Find("FoodLevel");
        wisdomLevel = GameObject.Find("WisdomLevel");

        continueButton = GameObject.Find("Continue");
        continueButtonText = GameObject.Find("ContinueText");

        DisableContinue();

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
            button1Text,
            button2Text,
            button3Text,
            button4Text,
            button5Text
        };

        statTexts = new GameObject[]
        {
            foodLevel,
            wisdomLevel
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

        foreach(GameObject button in buttonTexts)
        {
            button.GetComponent<Text>().text = " ";
        }

        foreach (GameObject stat in statTexts)
        {
            stat.GetComponent<Text>().text = " ";
        }

        DisableContinue();

        continueButtonText.GetComponent<Text>().text = " ";
    }

    void UpdateUIAccordingToEvent()
    {
        ResetTexts();
        Event currentEvent = eventManager.CurrentEvent;
        image.GetComponent<Image>().sprite = currentEvent.image;
        description.GetComponent<Text>().text = currentEvent.description;

        button1Text.GetComponent<Text>().text = getButtonText(currentEvent.event1);
        button2Text.GetComponent<Text>().text = getButtonText(currentEvent.event2);
        button3Text.GetComponent<Text>().text = getButtonText(currentEvent.event3);
        button4Text.GetComponent<Text>().text = getButtonText(currentEvent.event4);
        button5Text.GetComponent<Text>().text = getButtonText(currentEvent.event5);

        foodLevel.GetComponent<Text>().text = eventManager.Food.ToString();
        wisdomLevel.GetComponent<Text>().text = eventManager.Wisdom.ToString();

        for (int i = 0; i < buttonTexts.Length; i++)
        {
            if (buttonTexts[i].GetComponent<Text>().text == " ")
            {
                buttons[i].GetComponent<Image>().enabled = false;
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }

        if (currentEvent.isLastEventInEncounter())
        {
            EnableContinue();
        }
    }

    private string getButtonText(Event eventToCheck)
    {
        if (eventToCheck != null)
        {
            return eventToCheck.buttonText;
        }

        return " ";
    }

    public void ButtonOneDo()
    {
        Event currentEvent = eventManager.CurrentEvent;
        eventManager.CurrentEvent = currentEvent.event1;
    }

    public void ButtonTwoDo()
    {
        Event currentEvent = eventManager.CurrentEvent;
        eventManager.CurrentEvent = currentEvent.event2;
    }

    public void ButtonThreeDo()
    {
        Event currentEvent = eventManager.CurrentEvent;
        eventManager.CurrentEvent = currentEvent.event3;
    }

    public void ButtonFourDo()
    {
        Event currentEvent = eventManager.CurrentEvent;
        eventManager.CurrentEvent = currentEvent.event4;
    }

    public void ButtonFiveDo()
    {
        Event currentEvent = eventManager.CurrentEvent;
        eventManager.CurrentEvent = currentEvent.event5;
    }

    public void Continue()
    {
        eventManager.Continue(eventManager.CurrentEvent.continueIntruction);
    }

    private void EnableContinue()
    {
        continueButton.GetComponent<Image>().enabled = defaultButton;
        continueButton.GetComponent<Button>().interactable = true;
        continueButtonText.GetComponent<Text>().text = "Continue";
    }

    private void DisableContinue()
    {
        continueButton.GetComponent<Image>().enabled = false;
        continueButton.GetComponent<Button>().interactable = false;
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
