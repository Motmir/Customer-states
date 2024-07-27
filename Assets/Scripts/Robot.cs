using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private LevelControl manager;
    private GameObject torso;

    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.Find("LevelManager").GetComponent<LevelControl>();
        torso = this.gameObject.transform.Find("torso").gameObject;
        torso.GetComponent<HingeJoint2D>().connectedBody = manager.conveyorClaw.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Discard()
    {
        torso.GetComponent<HingeJoint2D>().enabled = false;
    }   
}
