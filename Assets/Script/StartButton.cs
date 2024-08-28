using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        TimerManager.instance.StartTimer();

    }
}
