using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ohno : MonoBehaviour
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

		public void LoadScene()
    {
        
        SceneManager.LoadScene(1);
        //PlayerMovement.movement = Vector3.zero;
        
    }
}
