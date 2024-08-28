using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour
{
    public Button yourButton; // Assign your button in the Inspector
    public AudioClip clickSound; // Renamed to follow camelCase convention
    private AudioSource audioSource; // AudioSource component

    void Start()
    {
        
        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        
      
            yourButton.onClick.AddListener(LoadScene);
    
    }

    void LoadScene()
    {
        PlaySound();

        
        Invoke("LoadSceneDelayed", 1f);
    }

    void LoadSceneDelayed()
    {
        SceneManager.LoadScene(2);
      //  PlayerMovement.movement = Vector3.zero;

    }

    void PlaySound()
    {
        
        
            audioSource.PlayOneShot(clickSound);
        
    }
}
