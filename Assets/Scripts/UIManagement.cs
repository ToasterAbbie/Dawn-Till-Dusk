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
                        foodLevelIcon,
                        pointer,
                        continueButton,
                        continueButtonText;

    private GameObject[] buttonTexts, buttons;

    public Sprite defaultButton;

    void Start()
    {
        image = GameObject.Find("EventImage");
        foodLevelIcon = GameObject.Find("FoodLevelIcon");
        pointer = GameObject.Find("Pointer");
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
        
        DisableContinue();

        continueButtonText.GetComponent<Text>().text = " ";
    }

    void UpdateUIAccordingToEvent()
    {
        ResetTexts();
        Event currentEvent = eventManager.CurrentEvent;
        image.GetComponent<Image>().sprite = currentEvent.image;
        UpdateFoodIcon();
        UpdateSlider();
        description.GetComponent<Text>().text = currentEvent.description;

        button1Text.GetComponent<Text>().text = getButtonText(currentEvent.event1);
        button2Text.GetComponent<Text>().text = getButtonText(currentEvent.event2);
        button3Text.GetComponent<Text>().text = getButtonText(currentEvent.event3);
        button4Text.GetComponent<Text>().text = getButtonText(currentEvent.event4);
        button5Text.GetComponent<Text>().text = getButtonText(currentEvent.event5);
        
        for (int i = 0; i < buttonTexts.Length; i++)
        {
            if (buttonTexts[i].GetComponent<Text>().text == " ")
            {
                buttons[i].GetComponent<Image>().enabled = false;
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }

        if (currentEvent.IsLastEventInEncounter())
        {
            EnableContinue();
        }
    }

    private void UpdateFoodIcon()
    {
        foodLevelIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("EventImages/FoodIcons/Hunger" + eventManager.Food.ToString());
    }

    private void UpdateSlider()
    {
        pointer.GetComponent<RectTransform>().position = new Vector3(eventManager.Wisdom * GetPointerMultiplier(), pointer.GetComponent<RectTransform>().position.y, pointer.GetComponent<RectTransform>().position.z);
    }

    private float GetPointerMultiplier()
    {
        float max = 2.35f;
        float min = -2.35f;

        float maxWisdom = 5;
        float minWisdom = -5;

        float resultWidth = max - min;
        float valueWidth = maxWisdom - minWisdom;

        float multiplier = resultWidth / valueWidth;
        return multiplier;
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
        SetNextEvent(eventManager.CurrentEvent.event1);
    }

    public void ButtonTwoDo()
    {
        SetNextEvent(eventManager.CurrentEvent.event2); ;
    }

    public void ButtonThreeDo()
    {
        SetNextEvent(eventManager.CurrentEvent.event3);
    }

    public void ButtonFourDo()
    {
        SetNextEvent(eventManager.CurrentEvent.event4);
    }

    public void ButtonFiveDo()
    {
        SetNextEvent(eventManager.CurrentEvent.event5);
    }

    private void SetNextEvent(Event nextEvent)
    {
        Event oldEvent = eventManager.CurrentEvent;
        eventManager.CurrentEvent = nextEvent;

        if (oldEvent.isContinueScreen)
        {
            Continue();
        }
    }

    public void Continue()
    {
        eventManager.Continue(eventManager.CurrentEvent.continueIntruction);
    }

    private void EnableContinue()
    {
        continueButton.GetComponent<Image>().enabled = defaultButton;
        continueButton.GetComponent<Button>().interactable = true;
        continueButtonText.GetComponent<Text>().text = GetContinueText();
    }

    private string GetContinueText()
    {
        if (string.IsNullOrEmpty(eventManager.CurrentEvent.continueText))
        {
            return "Continue";
        }
        else
        {
            return eventManager.CurrentEvent.continueText;
        }
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
