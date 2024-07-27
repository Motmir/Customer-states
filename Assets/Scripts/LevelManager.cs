using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelControl : MonoBehaviour
{
    [NonSerialized] public GameObject conveyorArm;
    [NonSerialized] public GameObject conveyorClaw;

    [SerializeField] GameObject robotPrefab;
    public GameObject robot;
    public Robot roboScript;
    [NonSerialized] public bool done;
    [SerializeField] private GameObject userInterface;
    public int scene;

    // Start is called before the first frame update
    void Start()
    {
        conveyorArm = GameObject.Find("arm_base");
        conveyorClaw = GameObject.Find("conveyor_claw");
        done = false;
        float xPos = Camera.main.ScreenToWorldPoint(conveyorArm.transform.position).x;
        float yPos = Camera.main.ScreenToWorldPoint(conveyorArm.transform.position).y;
        robot = Instantiate(this.robotPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        roboScript = robot.GetComponent<Robot>();
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
