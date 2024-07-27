using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private LevelControl manager;
    private GameObject head;
    private GameObject torso;
    private GameObject leftLeg;
    private GameObject rightLeg;
    private GameObject leftArm;
    private GameObject rightArm;

    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.Find("LevelManager").GetComponent<LevelControl>();
        torso = this.gameObject.transform.Find("torso").gameObject;
        head = this.gameObject.transform.Find("head").gameObject;
        leftLeg = this.gameObject.transform.Find("leftLeg").gameObject;
        rightLeg = this.gameObject.transform.Find("rightLeg").gameObject;
        leftArm = this.gameObject.transform.Find("leftArm").gameObject;
        rightArm = this.gameObject.transform.Find("rightArm").gameObject;

        torso.GetComponent<HingeJoint2D>().connectedBody = manager.conveyorClaw.GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    public void Discard()
    {
        torso.GetComponent<HingeJoint2D>().enabled = false;
    }   
}
