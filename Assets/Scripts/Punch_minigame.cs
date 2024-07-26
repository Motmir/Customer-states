using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Punch_minigame : MonoBehaviour
{
    [SerializeField] private InputAction punchAction;

    private void OnEnable()
    {
        punchAction.Enable();
    }

    private void OnDisable()
    {
        punchAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject progressBar = GameObject.Find("Bar");
        Debug.Log(punchAction.triggered);
        if (punchAction.triggered != false)
        {
            progressBar.GetComponent("Image")
        }
    }
}
