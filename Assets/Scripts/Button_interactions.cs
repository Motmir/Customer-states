using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_interactions : MonoBehaviour
{
    //public GameObject current_robot;
    public void Send_out()
    {
        GameObject current_robot = GameObject.Find("Robot");
        Rigidbody2D robot_rb = current_robot.GetComponent<Rigidbody2D>();
        robot_rb.velocity = Vector3.right;
        Destroy(current_robot, 5f);
    }

    public void Discard()
    {
        GameObject current_robot = GameObject.Find("Robot");
        Rigidbody2D robot_rb = current_robot.GetComponent<Rigidbody2D>();
        robot_rb.velocity = Vector3.down;
        Destroy(current_robot, 2f);
    }
}
