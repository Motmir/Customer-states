using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treatments : MonoBehaviour
{
    [SerializeField] private GameObject punchMinigame;
    [SerializeField] private GameObject wash;

    public void treatmentOne()
    {
        Debug.Log("Treatment number 1 is now active");
        punchMinigame.SetActive(true);
    }
    public void treatmentTwo()
    {
        Debug.Log("Treatment number 2 is now active");
        wash.SetActive(true);
    }
    public void treatmentThree()
    {
        Debug.Log("Treatment number 3 is now active");
        GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>().TogglePower();
    }
}
