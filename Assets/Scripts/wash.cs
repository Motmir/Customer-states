using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GameComplete", 3f);
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
