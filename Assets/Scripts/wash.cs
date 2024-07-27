using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wash : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("GameComplete", 1.1f);
    }


    private void GameComplete()
    {
        GameObject wash = GameObject.Find("Wash");
        GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>().Wash();
        wash.SetActive(false);
    }
}
