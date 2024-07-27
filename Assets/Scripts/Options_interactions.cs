using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class Options_interactions : MonoBehaviour
{
    public TextMeshProUGUI toggleText;
    public void Start()
    {
        toggleText = GameObject.Find("on/off").GetComponent<TextMeshProUGUI>();
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
}
