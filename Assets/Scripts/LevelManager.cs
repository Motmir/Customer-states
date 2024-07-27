using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject conveyorArm;
    public GameObject conveyorClaw;

    [SerializeField] GameObject[] robots;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        conveyorArm = GameObject.Find("arm_base");
        conveyorClaw = GameObject.Find("conveyor_arm");
        done = false;
        
        GameObject robotPrefab = robots[Random.Range(0,robots.Length)];
        Instantiate(robotPrefab, conveyorArm.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (conveyorArm.transform.position.x <= 0 || 
            (done == true && conveyorArm.transform.position.x <= 500))
        {
            Debug.Log("Less than 0");
            conveyorArm.GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
        }
        else if (conveyorArm.transform.position.x >= 0)
        { 
            Debug.Log("More than 0");
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
