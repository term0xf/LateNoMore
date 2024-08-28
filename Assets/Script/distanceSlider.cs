using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DistanceBasedSlider : MonoBehaviour
{
    public Slider distanceSlider;  // Reference to the UI Slider
    public GameObject mapObject;   // Reference to the Map object
    public float maxDistance = 100f;  // Maximum distance at which the slider is 0
    public float minDistance = 5f;    // Minimum distance at which the slider is 1
    public Button Button;
    public List<Button> Movements;
    public Button Button1;

    private void Start()
    {
        if (mapObject == null)
        {
            mapObject = GameObject.FindGameObjectWithTag("School");
        }

        Button.gameObject.SetActive(false);
       
    }

    private void Update()
    {
        if (mapObject != null && distanceSlider != null)
        {
            float distance = Vector3.Distance(transform.position, mapObject.transform.position);

            // Calculate the slider value based on the distance
            float normalizedDistance = (maxDistance - distance) / (maxDistance - minDistance);

            // Ensure the slider value is within the range [0, 1]
            distanceSlider.value = Mathf.Clamp01(normalizedDistance);
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "School")
        {

            SceneManager.LoadScene(5);
            Button1.gameObject.SetActive(true);


        }
    }
    void hideButtons(List<Button> buttons)
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false;



        }

    }
    void Showbuttons(List<Button> buttons)
    { 
    
      

        foreach (Button button in buttons)
        {

            button.gameObject.SetActive(true);
            button.interactable = true;


        }
        
        
    

    }

}