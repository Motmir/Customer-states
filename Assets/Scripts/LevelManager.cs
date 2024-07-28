using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelControl : MonoBehaviour
{
    [NonSerialized] public GameObject conveyorArm;
    [NonSerialized] public GameObject conveyorClaw;
    [SerializeField] public RobotSet[] robotSets;
    [SerializeField] GameObject robotPrefab;
    public GameObject robot;
    public Robot roboScript;
    [NonSerialized] public bool done;
    [SerializeField] private GameObject userInterface;
    public int scene;
    private GameObject crane;

    // Start is called before the first frame update
    public void Start()
    {
        conveyorArm = GameObject.Find("arm_base");
        conveyorClaw = GameObject.Find("conveyor_claw");
        done = false;
        float xPos = Camera.main.ScreenToWorldPoint(conveyorArm.transform.position).x;
        float yPos = Camera.main.ScreenToWorldPoint(conveyorArm.transform.position).y;
        robot = Instantiate(this.robotPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        roboScript = robot.GetComponent<Robot>();
        crane = GameObject.Find("Crane");
    }

    public void FetchNextRobot()
    {
        float xPos = Camera.main.ScreenToWorldPoint(conveyorArm.transform.position).x;
        float yPos = Camera.main.ScreenToWorldPoint(conveyorArm.transform.position).y;
        robot = Instantiate(this.robotPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        DisableRobotCollision();
        Invoke("EnableRobotCollision", 2f);
    }

    // Update is called once per frame
    void Update()
    {
                
        if (conveyorArm.transform.position.y != 3.88f)
        {
            crane.transform.position = new Vector3(0, 0, 0);
            conveyorArm.transform.position = new Vector3(conveyorArm.transform.position.x, 3.88f, conveyorArm.transform.position.z);
        }
        if (conveyorArm.transform.position.x <= 0 || 
            (done == true && conveyorArm.transform.position.x <= 15))
        {
            userInterface.SetActive(false);
            conveyorArm.GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
        }
        else if (conveyorArm.transform.position.x >= 0)
        {
            userInterface.SetActive(true);
            conveyorArm.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (conveyorArm.transform.position.x >= 15)
            {
                Destroy(robot);
                crane.SetActive(false);
                conveyorArm.transform.position = new Vector3(-25, 3.88f, -0.1f);
                crane.SetActive(true);
                Invoke("FetchNextRobot", 0.4f);
                done = false;
            }
        }
    }

    public void DisableRobotCollision()
    {
        //Disable torso
        robot.GetComponentInChildren<BoxCollider2D>().enabled = false;
        //Disable the rest
        robot.GetComponentInChildren<CapsuleCollider2D>().enabled = false;
    }

    public void EnableRobotCollision()
    {
        //Enable torso
        robot.GetComponentInChildren<BoxCollider2D>().enabled = true;
        //Enable the rest
        robot.GetComponentInChildren<CapsuleCollider2D>().enabled = true;
    }

    public void setDone()
    {
        done = true;
    }
    public void DiscardDone()
    {
        robot.GetComponent<Robot>().Discard();
        conveyorClaw.GetComponent<claw>().Open();
        Invoke("setDone", 0.5f);
        Invoke("CloseClaw", 1f);
    }

    private void CloseClaw()
    {
        conveyorClaw.GetComponent<claw>().Close();
    }

    private void Awake()
    {
        scene = SceneManager.GetActiveScene().buildIndex;

        if (scene == 1)
        {
            Destroy(GameObject.Find("BackgroundMusic"));
        }

    }

}
