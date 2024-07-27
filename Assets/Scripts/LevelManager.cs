using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject conveyorArm;
    public GameObject conveyorClaw;

    [SerializeField] GameObject[] robots;
    [NonSerialized] public bool done;
    [SerializeField] private GameObject userInterface;
    // Start is called before the first frame update
    void Start()
    {
        conveyorArm = GameObject.Find("arm_base");
        conveyorClaw = GameObject.Find("conveyor_arm");
        done = false;
        
        GameObject robotPrefab = robots[UnityEngine.Random.Range(0,robots.Length-1)];
        Instantiate(robotPrefab, conveyorArm.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (conveyorArm.transform.position.x <= 0 || 
            (done == true && conveyorArm.transform.position.x <= 500))
        {
            userInterface.SetActive(false);
            conveyorArm.GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
        }
        else if (conveyorArm.transform.position.x >= 0)
        {
            userInterface.SetActive(true);
            conveyorArm.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void setDone()
    {
        done = true;
    }
    public void DiscardDone()
    {
        robots[0].GetComponent<Robot>().Discard();
        Invoke("setDone", 0.5f);
    }

}
