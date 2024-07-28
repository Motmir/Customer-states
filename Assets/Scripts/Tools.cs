using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    [SerializeField] private GameObject screwdriver;
    [SerializeField] private GameObject blowtorch;
    public void toolOne()
    {
        if (screwdriver.gameObject.activeSelf)
        {
            screwdriver.SetActive(false);
        } else
        {
            screwdriver.SetActive(true);
        }
        
    }
    public void toolTwo()
    {
        if (blowtorch.gameObject.activeSelf)
        {
            blowtorch.SetActive(false);
        }
        else
        {
            blowtorch.SetActive(true);
        }
        
    }
}
