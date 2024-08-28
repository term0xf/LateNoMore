using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSequenceChecker : MonoBehaviour
{
    private List<int> pressedSequence = new List<int>();
    private List<int> correctSequence = new List<int> { 1, 2, 3, 4, 5 };
    private Dictionary<int, bool> buttonPressedStatus = new Dictionary<int, bool>();

    public GameObject wrongSequenceObject;
    public Button retryButton;
    public Slider timerSlider;
    public Button startButton;
    public List<Button> sequenceButtons;
    public List<Button> additionalButtons;
    public AudioClip correctSound;
    public AudioClip timerSound; 
    public AudioClip failSound;

    private AudioSource audioSource;
    private bool isTimerRunning = false;
    private float timeRemaining = 10f;

    public GameObject displayPanel;
    public GameObject targetObject;
    public GameObject displayPanel2;

    void Start()
    {
        HideButtons(sequenceButtons);
        displayPanel2.SetActive(false);
        displayPanel.SetActive(false);
        retryButton.gameObject.SetActive(false);
        timerSlider.maxValue = 10f;
        timerSlider.value = 10f;
        timerSlider.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartGame);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeRemaining -= Time.deltaTime;
            timerSlider.value = timeRemaining;

            if (timeRemaining <= 0)
            {
                isTimerRunning = false;
                ShowWrongSequenceObject();
            }
        }
    }

    void AddButtonListener(Button button, int buttonID)
    {
        button.onClick.AddListener(delegate { OnButtonPress(button, buttonID); });
        buttonPressedStatus[buttonID] = false;
    }

    void OnButtonPress(Button button, int buttonID)
    {
        if (!isTimerRunning)
            return;

        
        bool isPressed = !buttonPressedStatus[buttonID];
        buttonPressedStatus[buttonID] = isPressed;

        if (isPressed)
        {
            button.GetComponent<Image>().color = Color.green; // Select color
            pressedSequence.Add(buttonID);
        }
        else
        {
            button.GetComponent<Image>().color = Color.white; // Deselect color
            pressedSequence.Remove(buttonID);
        }

        if (pressedSequence.Count > correctSequence.Count)
        {
            pressedSequence.RemoveAt(0); // Keep the sequence length same as correctSequence
        }

        Debug.Log("Pressed sequence: " + string.Join(", ", pressedSequence));

        if (CheckSequence())
        {
            ExecuteAction();
        }
        else if (pressedSequence.Count == correctSequence.Count)
        {
            ShowWrongSequenceObject();
        }
    }

    bool CheckSequence()
    {
        if (pressedSequence.Count != correctSequence.Count)
        {
            return false;
        }

        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (pressedSequence[i] != correctSequence[i])
            {
                Debug.Log("Sequence mismatch at index " + i);
                return false;
            }
        }

        return true;
    }

    void ExecuteAction()
    {
        isTimerRunning = false;
        timerSlider.gameObject.SetActive(false);
        displayPanel.SetActive(false);
        displayPanel2.SetActive(true);

        if (audioSource != null)
        {
            audioSource.Stop(); // Stop the timer sound
            if (correctSound != null)
            {
                audioSource.PlayOneShot(correctSound);
            }
        }

        ShowButtons(additionalButtons);
        
        HideButtons(sequenceButtons);

        if (targetObject != null)
        {
            targetObject.tag = "Bus4";
        }
        
    }

    void ShowWrongSequenceObject()
    {
        Debug.Log("Wrong sequence entered");
        wrongSequenceObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        isTimerRunning = false;
        timerSlider.gameObject.SetActive(false);
        displayPanel.SetActive(false);

        if (audioSource != null)
        {
            audioSource.Stop(); // Stop the timer sound
        }

        // Hide buttons
        HideButtons(sequenceButtons);
        HideButtons(additionalButtons);
        if (audioSource != null && failSound != null)
        {
            audioSource.PlayOneShot(failSound);
        
        }

    }

    void StartTimer()
    {
        isTimerRunning = true;
        timeRemaining = 10f;
        timerSlider.value = 10f;
        timerSlider.gameObject.SetActive(true);
        displayPanel.SetActive(true);

        if (audioSource != null && timerSound != null)
        {
            audioSource.clip = timerSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void StartGame()
    {
        // Show sequence buttons
        ShowButtons(sequenceButtons);

        for (int i = 0; i < sequenceButtons.Count; i++)
        {
            AddButtonListener(sequenceButtons[i], i + 1);
        }

        startButton.gameObject.SetActive(false);
        StartTimer();
    }

    void ShowButtons(List<Button> buttons)
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
            button.interactable = true;
        }
    }

    void HideButtons(List<Button> buttons)
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
