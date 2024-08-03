using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.GoogleVr;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static RobotPart;

public class ScoreManagerScript : MonoBehaviour
{
    private int totalScore = 0;
    private int score = 100;
    private int day = 1;

    private int DIRTYPOINT = 5;
    private int EVILPOINT = 100;
    private int WRONGPOINT = 10;
    private int BROKENPOINT = 10;
    private int MISSINGPOINT = 25;
    private int LOOSEPOINT = 15;

    private int robotsCompleted = 0;
    private int evilCount = 0;
    private int somethingWrongCount = 0;
    private int dirtyPartsCount = 0;
    private int brokenPartsCount = 0;
    private int loosePartsCount = 0;
    private int missingPartsCount = 0;

    private bool discarded = false;

    private GameObject robotObject;
    private Robot robot;
    private RobotPart[] parts;

    [SerializeField] private GameObject endOfLevelCanvasObject;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject dayTextObject;



    public void getStuff()
    {
        robot = GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>();
        robotObject = GameObject.Find("LevelManager").GetComponent<LevelControl>().robot;

        parts = robotObject.GetComponentsInChildren<RobotPart>();
    }

    public void NewRobotSpawned()
    {
        score = 100;
        discarded = false;
        foreach (RobotPart part in parts)
        {
            if (part.GetComponent<HingeJoint2D>().IsDestroyed())
            {
                score += MISSINGPOINT;
                missingPartsCount--;
            }
        }
    }

    public void RobotDiscarded()
    {
        score = 0;
        discarded = true;
    }

    public void calculateRobotScore()
    {
        if (!discarded)
        {
            if (robot.evil)
            {
                score -= EVILPOINT;
                evilCount++;
            }
            if (robot.somethingWrong)
            {
                score -= WRONGPOINT;
                somethingWrongCount++;
            }
            // robot.on
            foreach (RobotPart part in parts)
            {
                if (part.isDirty)
                {
                    score -= DIRTYPOINT;
                    dirtyPartsCount++;
                }
                if (part.isBroken > 0)
                {
                    score -= BROKENPOINT;
                    brokenPartsCount++;
                }
                if (part.isLoose > 0)
                {
                    score -= LOOSEPOINT;
                    loosePartsCount++;
                }
                if (robot.robotSet == Robot.RobotSetName.SecretaryGlasses)
                {
                    if (part.IAm == RobotPart.Part.Head && !part.GetComponent<HingeJoint2D>().IsDestroyed())
                    {
                        score -= 100;
                        somethingWrongCount++;
                    } else
                    {
                        score += 100;
                        score += MISSINGPOINT;
                    }
                } else if (robot.robotSet == Robot.RobotSetName.Roomba)
                {
                    if (part.IAm == RobotPart.Part.Head && !part.GetComponent<HingeJoint2D>().IsDestroyed())
                    {
                        score -= 100;
                        somethingWrongCount++;
                    }
                }
                // TODO: Unntak for Roomba (knife) og Secretary (briller)
                // has it fallen off?
                if (part.GetComponent<HingeJoint2D>().IsDestroyed())
                {
                    
                    score -= MISSINGPOINT;
                    missingPartsCount++;
                }
            }
            robotsCompleted++;
        }
        print("Score: " + score + "| Total: " + totalScore);
        totalScore += score;
    }


    public void DisplayScore()
    {
        Time.timeScale = 0;
        //endOfLevelCanvas = GameObject.Find("EndOfLevelCanvas").gameObject;
        //scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        string title = string.Format("Score of Day {0} \n", day);
        string robots = string.Format("Number of robots completed {0} = {1}\n", robotsCompleted, robotsCompleted * 100);
        string dirty = string.Format("{0}x dirty bodyparts = -{1} \n", dirtyPartsCount, dirtyPartsCount * DIRTYPOINT);
        string missing = string.Format("{0}x missing bodyparts = -{1} \n", missingPartsCount, missingPartsCount * MISSINGPOINT);
        string broken = string.Format("{0}x broken bodyparts = -{1} \n", brokenPartsCount, brokenPartsCount * BROKENPOINT);
        string loose = string.Format("{0}x loose bodyparts = -{1} \n", loosePartsCount, loosePartsCount * LOOSEPOINT);
        string somethingWrong = string.Format("{0}x not rebooted because of behavour = -{1} \n", somethingWrongCount, somethingWrongCount * WRONGPOINT);
        string evil = string.Format("{0}x evil = -{1} \n", evilCount, evilCount * EVILPOINT);
        string sum = string.Format("Total points: {0}", totalScore);

        scoreTextObject.GetComponent<TextMeshProUGUI>().text = title + robots + dirty+ missing + broken + loose + somethingWrong + evil + sum;
        endOfLevelCanvasObject.SetActive(true);

    }

    public void RemoveScoreBoard()
    {
        day++;
        Time.timeScale = 1;
        GameObject.Find("LevelManager").GetComponent<LevelControl>().NextLevel();
        endOfLevelCanvasObject.SetActive(false);
        dayTextObject.GetComponent<TextMeshProUGUI>().text = string.Format("Day {0}/6", day);
    }



}
