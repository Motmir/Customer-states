using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public enum RobotSetName { 
        Random, 
        Roomba,
        SecretaryGlasses,
        Secretary,
        Handsome,
        Maid,
        Orbot,
        Tanner,
        Scrappy,
        Caroline,
        TVbot
    }

    Dictionary<RobotSetName, RobotSet> musicDatabase = new Dictionary<RobotSetName, RobotSet>();

    [SerializeField] private LevelControl manager;
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject torso;
    [SerializeField] private GameObject leftLeg;
    [SerializeField] private GameObject rightLeg;
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject leftPunch;
    [SerializeField] private GameObject rightPunch;

    public bool evil = false;
    public bool somethingWrong = false;
    public bool on = false;

    public void Init(RobotInstanceInfo instance){
        evil = instance.evil;
        on = instance.on;
        somethingWrong = instance.somethingWrong;
        UpdateRobotPart(instance.partsSet, instance.head, head);
        UpdateRobotPart(instance.partsSet, instance.torso, torso);
        UpdateRobotPart(instance.partsSet, instance.leftLeg, leftLeg);
        UpdateRobotPart(instance.partsSet, instance.rightLeg, rightLeg);
        UpdateRobotPart(instance.partsSet, instance.leftArm, leftArm);
        UpdateRobotPart(instance.partsSet, instance.rightArm, rightArm);
    }

    void UpdateRobotPart(RobotSetName robotSet, RobotInstanceInfo.PartInfo partInstance, GameObject partObject)
    {
        RobotPart robotPart = partObject.GetComponent<RobotPart>();

        if (robotSet == RobotSetName.Random ){
            int length = Enum.GetValues(typeof(RobotSetName)).Length;
            int set = UnityEngine.Random.Range(3, length) - 1;
            robotPart.set =  manager.robotSets[set];
        } else {
            int set = (int)robotSet - 1;
            robotPart.set =  manager.robotSets[set];
        }

        Debug.Log(partInstance.dirt + " ?= " + RobotPart.Dirt.None);
        if (partInstance.dirt != RobotPart.Dirt.None)
        {
            robotPart.dirtSprite = manager.dirts[(int)partInstance.dirt - 1];
            robotPart.isDirty = true;
        }

        if (partInstance.sparking)
        {
            robotPart.isSparking = true;
        }

        if (partInstance.batterd)
        {
            robotPart.isBroken = 6;
        }

        if (partInstance.loose)
        {
            robotPart.isLoose = 6;
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.Find("LevelManager").GetComponent<LevelControl>();
        torso.GetComponent<HingeJoint2D>().connectedBody = manager.conveyorClaw.GetComponent<Rigidbody2D>();
        torso.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, -0.6f);

    }

    public void EnablePunch()
    {
        leftPunch.GetComponent<SpriteRenderer>().enabled = true;
        rightPunch.GetComponent<SpriteRenderer>().enabled = true;
        leftPunch.GetComponent<Animator>().enabled = true;
        rightPunch.GetComponent<Animator>().enabled = true;
    }

    public void EmitRight()
    {
        GameObject scraps = GameObject.Find("RightPunch/scraps");
        GameObject sparks = GameObject.Find("RightPunch/sparks");
        scraps.GetComponent<ParticleSystem>().Emit(2);
        sparks.GetComponent<ParticleSystem>().Emit(5);
        Debug.Log("Emitting right");
    }

    public void EmitLeft()
    {
        GameObject scraps = GameObject.Find("LeftPunch/scraps");
        GameObject sparks = GameObject.Find("LeftPunch/sparks");
        scraps.GetComponent<ParticleSystem>().Emit(2);
        sparks.GetComponent<ParticleSystem>().Emit(5);
        Debug.Log("Emitting left");
    }
    public void DisablePunch()
    {
        leftPunch.GetComponent<SpriteRenderer>().enabled = false;
        rightPunch.GetComponent<SpriteRenderer>().enabled = false;
        leftPunch.GetComponent<Animator>().enabled = false;
        rightPunch.GetComponent<Animator>().enabled = false;
    }


    // Update is called once per frame
    public void Discard()
    {
        torso.GetComponent<HingeJoint2D>().enabled = false;
    }
    public void Wash()
    {
        if (head) {
            head.GetComponent<RobotPart>().isDirty = false;
        }
        if (torso) {
            torso.GetComponent<RobotPart>().isDirty = false;
        }
        if (leftArm) {
            leftArm.GetComponent<RobotPart>().isDirty = false;
        }
        if (rightArm) {
            rightArm.GetComponent<RobotPart>().isDirty = false;
        }
        if (leftLeg) {
            leftLeg.GetComponent<RobotPart>().isDirty = false;
        }
        if (rightLeg) {
            rightLeg.GetComponent<RobotPart>().isDirty = false;
        }
    }
    public void TogglePower()
    {
        on = !on;
    }
}
