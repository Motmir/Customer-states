using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Robot;

public class Levels : MonoBehaviour
{
    public GameObject robot;
    public Robot.RobotInstance[] levelInstances = new Robot.RobotInstance[3]
    {
        new Robot.RobotInstance
        {
            partsSet = "Random",
            evil = false,
            on = false,

            head = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            torso = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            leftArm = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            rightArm = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            leftLeg = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            rightLeg = new Robot.Condititions [1] {Robot.Condititions.Bloody},
        },
        new Robot.RobotInstance
        {
            partsSet = "Random",
            evil = false,
            on = false,

            head = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            torso = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            leftArm = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            rightArm = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            leftLeg = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            rightLeg = new Robot.Condititions [1] {Robot.Condititions.Bloody},
        },
        new Robot.RobotInstance
        {
            partsSet = "Random",
            evil = false,
            on = false,

            head = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            torso = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            leftArm = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            rightArm = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            leftLeg = new Robot.Condititions [1] {Robot.Condititions.Bloody},
            rightLeg = new Robot.Condititions [1] {Robot.Condititions.Bloody},
        }
    };    
}
