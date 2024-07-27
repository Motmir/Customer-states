using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    GameObject conveyorArm;
    [SerializeField] private GameObject userInterface;
    [NonSerialized] public bool done;
    // Start is called before the first frame update
    void Start()
    {
        conveyorArm = GameObject.Find("arm_base");
        done = false;
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
    public void discardDone()
    {
        Invoke("setDone", 0.5f);
    }

}
