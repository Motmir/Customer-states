using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RobotInstanceInfo : ScriptableObject
{
    public string partsSet;
    public bool evil;
    public bool on;

    //Contidtions affecting part
    public Robot.Condititions[] head;
    public Robot.Condititions[] torso;
    public Robot.Condititions[] leftArm;
    public Robot.Condititions[] rightArm;
    public Robot.Condititions[] leftLeg;
    public Robot.Condititions[] rightLeg;
}