 using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene3 : MonoBehaviour
{
    public Button yourButton; // Assign your button in the Inspector

    void Start()
    {
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(LoadScene);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(3);
    }
}
