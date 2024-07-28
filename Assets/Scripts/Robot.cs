using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public enum RobotSetName { 
        Random, 
        Roomba,
        SecretaryGlasses
        Caroline,
        Handsome,
        Maid,
        Orbot,
        Tanner,
        Scrappy,
        TVbot
    }
    public enum Dirt {None, Bloody, Dirty, Screw , Drawing, Oil}

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


    private RobotSet headSet;
    private RobotSet torsoSet;
    private RobotSet leftLegSet;
    private RobotSet rightLegSet;
    private RobotSet leftArmSet;
    private RobotSet rightArmSet;
    private bool evil = false;
    private bool somethingWrong = false;
    public bool on = false;

    public void Init(RobotInstanceInfo instance){
        evil = instance.evil;
        on = instance.on;
        somethingWrong = instance.somethingWrong;
        if (instance.partsSet == RobotSetName.Random ){
            int length = Enum.GetValues(typeof(RobotSetName)).Length;
            int set = UnityEngine.Random.Range(3, length) - 1;
            headSet =  manager.robotSets[set];
            set = UnityEngine.Random.Range(3, length) - 1;
            torsoSet =  manager.robotSets[set];
            set = UnityEngine.Random.Range(3, length) - 1;
            leftLegSet =  manager.robotSets[set];
            set = UnityEngine.Random.Range(3, length) - 1;
            rightLegSet =  manager.robotSets[set];
            set = UnityEngine.Random.Range(3, length) - 1;
            leftArmSet =  manager.robotSets[set];
            set = UnityEngine.Random.Range(3, length) - 1;
            rightArmSet =  manager.robotSets[set];
        } else {
            int set = (int)instance.partsSet - 1;
            headSet =  manager.robotSets[set];
            torsoSet =  manager.robotSets[set];
            leftLegSet =  manager.robotSets[set];
            rightLegSet =  manager.robotSets[set];
            leftArmSet =  manager.robotSets[set];
            rightArmSet =  manager.robotSets[set];
        }
        if (head) {
            if(on){
                head.GetComponent<SpriteRenderer>().sprite = headSet.headOn;
            } else {
                head.GetComponent<SpriteRenderer>().sprite = headSet.headOff;
            }
        }
        if (torso) {
            if(on){
                torso.GetComponent<SpriteRenderer>().sprite = torsoSet.torsoOn;
            } else {
                torso.GetComponent<SpriteRenderer>().sprite = torsoSet.torsoOff;
            }
        }
        if (leftArm) {
            leftArm.GetComponent<SpriteRenderer>().sprite = leftArmSet.arm;
        }
        if (rightArm) {
            rightArm.GetComponent<SpriteRenderer>().sprite = rightArmSet.arm;
        }
        if (leftLeg) {
            leftLeg.GetComponent<SpriteRenderer>().sprite = leftLegSet.leg;
        }
        if (rightLeg) {
            rightLeg.GetComponent<SpriteRenderer>().sprite = rightLegSet.leg;
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.Find("LevelManager").GetComponent<LevelControl>();
        torso = this.gameObject.transform.Find("torso").gameObject;
        Transform headTransform = this.gameObject.transform.Find("head");
        if (headTransform != null)
        {
            head = headTransform.gameObject;
        }
        Transform leftLegTransform = this.gameObject.transform.Find("leftLeg");
        if (leftLegTransform != null)
        {
            leftLeg = leftLegTransform.gameObject;
        }
        Transform rightLegTransform = this.gameObject.transform.Find("rightLeg");
        if (rightLegTransform != null)
        {
            rightLeg = rightLegTransform.gameObject;
        }
        Transform leftArmTransform = this.gameObject.transform.Find("leftArm");
        if (leftArmTransform != null)
        {
            leftArm = leftArmTransform.gameObject;
        }
        Transform rightArmTransform = this.gameObject.transform.Find("rightArm");
        if (rightArmTransform != null)
        {
            rightArm = rightArmTransform.gameObject;
        }

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
        if (head) {
            if(on){
                head.GetComponent<SpriteRenderer>().sprite = headSet.headOn;
            } else {
                head.GetComponent<SpriteRenderer>().sprite = headSet.headOff;
            }
        }
        if (torso) {
            if(on){
                torso.GetComponent<SpriteRenderer>().sprite = torsoSet.torsoOn;
            } else {
                torso.GetComponent<SpriteRenderer>().sprite = torsoSet.torsoOff;
            }
        }
    }
}
