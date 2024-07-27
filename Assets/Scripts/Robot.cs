using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private LevelControl manager;
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject torso;
    [SerializeField] private GameObject leftLeg;
    [SerializeField] private GameObject rightLeg;
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;

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



    // Update is called once per frame
    public void Discard()
    {
        torso.GetComponent<HingeJoint2D>().enabled = false;
    }
    public void Wash()
    {
        if (head) {
            Debug.Log("wash head");
            head.GetComponent<RobotPart>().isDirty = false;
        }
        if (torso) {
            Debug.Log("wash torso");
            torso.GetComponent<RobotPart>().isDirty = false;
        }
        if (leftArm) {
            Debug.Log("wash left arm");
            leftArm.GetComponent<RobotPart>().isDirty = false;
        }
        if (rightArm) {
            Debug.Log("wash right arm");
            rightArm.GetComponent<RobotPart>().isDirty = false;
        }
        if (leftLeg) {
            Debug.Log("wash left leg");
            leftLeg.GetComponent<RobotPart>().isDirty = false;
        }
        if (rightLeg) {
            Debug.Log("wash right leg");
            rightLeg.GetComponent<RobotPart>().isDirty = false;
        }
    }
    public void TogglePower()
    {

    }
}
