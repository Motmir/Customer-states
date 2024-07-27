using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    [SerializeField] private GameObject screwdriver;
    [SerializeField] private GameObject blowtorch;
    public void toolOne()
    {
        Debug.Log("Tool number 1 is now active");
        screwdriver.SetActive(true);
    }
    public void toolTwo()
    {
        Debug.Log("Tool number 2 is now active");
        blowtorch.SetActive(true);
    }
    public void toolThree()
    {
        Debug.Log("Tool number 3 is now active");
    }
}
