using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransparency : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
    }
   
}
