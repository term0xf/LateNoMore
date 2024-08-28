using UnityEngine;
using UnityEngine.UI;

public class CloseGameOnButtonPress : MonoBehaviour
{
    public Button yourButton; // Reference to the UI Button

    void Start()
    {
        
           
            yourButton.onClick.AddListener(CloseGame);
       

    }

    void CloseGame()
    {
        
        Application.Quit();




    }
}
