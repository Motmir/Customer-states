using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRightPunch : MonoBehaviour
{
    public void InvokeEffectRight()
    {
        GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>().EmitRight();
    }
}
