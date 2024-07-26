using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Punch_minigame : MonoBehaviour
{
    [SerializeField] private InputAction punchAction;
    private GameObject progressBar;
    private float progress;

    private void OnEnable()
    {
        punchAction.Enable();
        progress = 0;
        progressBar = GameObject.Find("Bar");
        StartCoroutine(ChangeBarColor());
    }
    private void OnDisable()
    {
        punchAction.Disable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (progressBar.GetComponent<Image>().fillAmount < 1)
        {
            if (punchAction.triggered != false)
            {
                progress = 0.05f;
            } else
            {
                progress = -0.003f;
            }
            
            progressBar.GetComponent<Image>().fillAmount += progress;
        }
    }

    private IEnumerator ChangeBarColor()
    {
        while (progressBar.GetComponent<Image>().fillAmount < 1)
        {
            progressBar.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, progressBar.GetComponent<Image>().fillAmount);
            yield return null;
        }
    }
}
