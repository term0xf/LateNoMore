using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button yourButton; // Reference to the UI Button

    void Start()
    {
        if (yourButton != null)
        {
            
            yourButton.onClick.AddListener(CloseGame);
        }

    }

    void CloseGame()
    {
        // Closes the application
        Application.Quit();

        // If running in the Unity editor, stop playing the scene
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
