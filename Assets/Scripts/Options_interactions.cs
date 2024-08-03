using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Options_interactions : MonoBehaviour
{
    public TextMeshProUGUI toggleText;
    public TextMeshProUGUI volumeText;
    public float volumeValue;

    public void Start()
    {
        toggleText = GameObject.Find("on/off").GetComponent<TextMeshProUGUI>();
        volumeText = GameObject.Find("volumeValue").GetComponent<TextMeshProUGUI>();
        
    }

    public void fullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void changeText()
    {
        if (toggleText.text == "Off")
            toggleText.text = "On";
        else
            toggleText.text = "Off";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        SceneManager.LoadScene(0);

        volumeValue = GameObject.Find("volumeSlider").GetComponent<Slider>().value;

        volumeText.text = "" + Mathf.Round(volumeValue *100);
    }
}
