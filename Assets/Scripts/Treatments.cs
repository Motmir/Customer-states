using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treatments : MonoBehaviour
{
    public GameObject punchMinigame;
    public void treatmentOne()
    {
        Debug.Log("Treatment number 1 is now active");
        punchMinigame.SetActive(true);
    }
    public void treatmentTwo()
    {
        Debug.Log("Treatment number 2 is now active");
    }
    public void treatmentThree()
    {
        Debug.Log("Treatment number 3 is now active");
    }
}
