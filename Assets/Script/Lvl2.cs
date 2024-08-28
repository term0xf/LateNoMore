using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Lvl2 : MonoBehaviour
{
    public GameObject Panel;
    public Button MainButton;

    public Button Button1;
    public Button Button2;
    public Button Button3;

    public Button Button4;
    public Button Button5;
    public Button Button6;

    public TextMeshProUGUI TextMeshProObject1; // For non-third buttons in both groups
    public TextMeshProUGUI TextMeshProObject2; // For the third button in the second group
    public Button retry;
    public GameObject LvlSec;
    public Button NextLvl;
    public GameObject LvlSecP2;
    public bool FirstQSuc = false;

    void Start()
    {
        MainButton.onClick.AddListener(() => ButtonClick(MainButton));

        Button1.onClick.AddListener(() => HandleButtonPress(Button1));
        Button2.onClick.AddListener(() => HandleButtonPress(Button2));
        Button3.onClick.AddListener(() => HandleButtonPress(Button3));
        Button4.onClick.AddListener(() => HandleButtonPress2(Button4));
        Button5.onClick.AddListener(() => HandleButtonPress2(Button5));
        Button6.onClick.AddListener(() => HandleButtonPress2(Button6));

        // Initial setup
        Panel.SetActive(true);
        MainButton.gameObject.SetActive(true);
        Button1.gameObject.SetActive(false);
        Button2.gameObject.SetActive(false);
        Button3.gameObject.SetActive(false);
        LvlSec.gameObject.SetActive(false);
        TextMeshProObject1.gameObject.SetActive(false);
        TextMeshProObject2.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);
        NextLvl.gameObject.SetActive(false);
        LvlSecP2.gameObject.SetActive(false);
    }

    void ButtonClick(Button button)
    {
        Panel.SetActive(false);
        MainButton.gameObject.SetActive(false);
        Button1.gameObject.SetActive(true);
        Button2.gameObject.SetActive(true);
        Button3.gameObject.SetActive(true);
        LvlSec.gameObject.SetActive(true);
    }

    void HandleButtonPress(Button button)
    {
        if (button == Button3)
        {
            FirstQSuc = true;
            Button1.gameObject.SetActive(false);
            Button2.gameObject.SetActive(false);
            Button3.gameObject.SetActive(false);
            LvlSec.gameObject.SetActive(false);
            Panel.SetActive(false);
            Button4.gameObject.SetActive(true);
            Button5.gameObject.SetActive(true);
            Button6.gameObject.SetActive(true);
            LvlSecP2.gameObject.SetActive(true);
        }
        else
        {
            Button1.gameObject.SetActive(false);
            Button2.gameObject.SetActive(false);
            Button3.gameObject.SetActive(false);
            LvlSec.gameObject.SetActive(false);
            Panel.SetActive(false);
            TextMeshProObject1.gameObject.SetActive(true); // Show text for non-third buttons
            retry.gameObject.SetActive(true);
        }
    }

    void HandleButtonPress2(Button button)
    {
        if (button == Button6)
        {
            TextMeshProObject2.gameObject.SetActive(true); // Show text for the third button in the second group
            retry.gameObject.SetActive(false);
            // Load scene 4
            SceneManager.LoadScene(3);
        }
        else
        {
            TextMeshProObject1.gameObject.SetActive(true); // Show text for non-third buttons
            retry.gameObject.SetActive(true);
        }

        Button4.gameObject.SetActive(false);
        Button5.gameObject.SetActive(false);
        Button6.gameObject.SetActive(false);
        LvlSecP2.gameObject.SetActive(false);
    }
}
