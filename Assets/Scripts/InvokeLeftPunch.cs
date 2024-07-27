using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeLeftPunch : MonoBehaviour
{
    public void InvokeEffectLeft()
    {
        GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>().EmitLeft();
    }
}
