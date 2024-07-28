using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treatments : MonoBehaviour
{
    [SerializeField] private GameObject punchMinigame;
    [SerializeField] private GameObject wash;

    public void treatmentOne()
    {
        punchMinigame.SetActive(true);
    }
    public void treatmentTwo()
    {
        wash.SetActive(true);
    }
    public void treatmentThree()
    {
        GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>().TogglePower();
    }
}
