using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RobotInstanceInfo : ScriptableObject
{

    [System.Serializable] public struct PartInfo {
        public bool partMissing;
        public RobotPart.Dirt dirt;
        public bool batterd;
        public bool loose;
        public bool sparking;
    }

    public Robot.RobotSetName partsSet;
    public bool evil;
    public bool on;
    public bool somethingWrong;

    //Contidtions affecting part
    public PartInfo head;
    public PartInfo torso;
    public PartInfo leftArm;
    public PartInfo rightArm;
    public PartInfo leftLeg;
    public PartInfo rightLeg;

    public DialogueInfo dialogue;
    public CustomerNoteInfo customerNote;
}