using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    public float timeRemaining = 600f; 
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;

    private GameObject timerObject;

    private void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (timeRemaining == 0)
            {

                timerObject.SetActive(false);
            }
        }
    }

    public void Start()
    {
    


        timerObject = GameObject.Find("TimerText");
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<TextMeshProUGUI>();
            timerObject.SetActive(true);
            UpdateTimerUI();
        }
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;

                

                timerObject.SetActive(false);
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void UpdateTimerUI()
    {
        
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
        timerObject = GameObject.Find("TimerText");
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<TextMeshProUGUI>();
            UpdateTimerUI();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
