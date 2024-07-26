using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_interactions : MonoBehaviour
{
    //public GameObject current_robot;
    public void Send_out()
    {
        GameObject currentRobot = GameObject.Find("Robot");
        Rigidbody2D robotRB = currentRobot.GetComponent<Rigidbody2D>();
        robotRB.velocity = Vector3.right;
        Destroy(currentRobot, 5f);
    }

    public void Discard()
    {
        GameObject currentRobot = GameObject.Find("Robot");
        Rigidbody2D robotRB = currentRobot.GetComponent<Rigidbody2D>();
        robotRB.velocity = Vector3.down;
        Destroy(currentRobot, 2f);
    }
}
