using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    void Start()
    {
        // Assuming the script is attached to a Button component, add a listener to the button click event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadScene);
        }
        
    }

    void LoadScene()
    {
        
        SceneManager.LoadScene(4);
        PlayerMovement.StopMovement();
        
    }
}
