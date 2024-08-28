using UnityEngine;

public class ShowButtonOnCollision : MonoBehaviour
{
    public GameObject buttonToShow;
    public GameObject[] buttonsToHide;
    public GameObject FirstMission;
    public GameObject PanelTohide;
    private bool buttonShown = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !buttonShown)
        {
            buttonToShow.SetActive(true);


            foreach (GameObject button in buttonsToHide)
            {
                button.SetActive(false);
                
            }
            FirstMission.SetActive(false);
            buttonShown = true;
            PanelTohide.SetActive(false);
            PlayerMovement.StopMovement();
        
        }
    }

}
