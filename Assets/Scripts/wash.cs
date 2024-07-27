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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameComplete()
    {
        GameObject wash = GameObject.Find("Wash");
        wash.SetActive(false);
    }
}
