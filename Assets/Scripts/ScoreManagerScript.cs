using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.GoogleVr;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    private int totalScore = 0;
    private int score = 100;
    private int POINT = 5;

    private int evilCount = 0;
    private int somethingWrongCount = 0;
    private int dirtyPartsCount = 0;
    private int brokenPartsCount = 0;
    private int loosePartsCount = 0;
    private int missingPartsCount = 0;

    private GameObject robotObject;
    private Robot robot;
    private RobotPart[] parts;

    [SerializeField] private GameObject endOfLevelCanvasObject;
    [SerializeField] private GameObject scoreTextObject;


    public void getStuff()
    {
        robot = GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>();
        robotObject = GameObject.Find("LevelManager").GetComponent<LevelControl>().robot;

        parts = robotObject.GetComponentsInChildren<RobotPart>();
    }

    public void calculateRobotScore()
    {
        score = 100;
        if (robot.evil)
        {
            score -= POINT;
            evilCount++;
        }
        if (robot.somethingWrong)
        {
            score -= POINT;
            somethingWrongCount++;
        }
        // robot.on
        foreach (RobotPart part in parts)
        {
            if (part.isDirty)
            {
                score -= POINT;
                dirtyPartsCount++;
            }
            if (part.isBroken > 0)
            {
                score -= POINT;
                brokenPartsCount++;
            }
            if (part.isLoose > 0)
            {
                score -= POINT;
                loosePartsCount++;
            }

            // TODO: Unntak for Roomba (knife) og Secretary (briller)
            // has it fallen off?
            if (part.GetComponent<HingeJoint2D>().IsDestroyed())
            {
                score -= POINT;
                missingPartsCount++;
            }
        }

        Debug.Log(score);
    }


    public void DisplayScore()
    {
        Time.timeScale = 0;
        //endOfLevelCanvas = GameObject.Find("EndOfLevelCanvas").gameObject;
        //scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        int day = 1;
        string title = string.Format("Score of Day {0} \n", day);
        string dirty = string.Format("{0}x dirty bodyparts -{1} \n", dirtyPartsCount, dirtyPartsCount*POINT);
        string missing = string.Format("{0}x missing bodyparts = -{1} \n", missingPartsCount, missingPartsCount * POINT);
        string broken = string.Format("{0}x broken bodyparts = -{1} \n", brokenPartsCount, brokenPartsCount * POINT);
        string loose = string.Format("{0}x loose bodyparts = -{1} \n", loosePartsCount, loosePartsCount * POINT);
        string somethingWrong = string.Format("{0}x something wrong = -{1} \n", somethingWrongCount, somethingWrongCount * POINT);
        string evil = string.Format("{0}x evil = -{1} \n", evilCount, evilCount * POINT);
        int tot = POINT * (dirtyPartsCount + missingPartsCount + brokenPartsCount + loosePartsCount + somethingWrongCount + evilCount);
        string sum = string.Format("Total points: {0}", tot);

        scoreTextObject.GetComponent<TextMeshProUGUI>().text = title + dirty+ missing + broken + loose + somethingWrong + evil;
        endOfLevelCanvasObject.SetActive(true);

    }

    public void RemoveScoreBoard()
    {
        Time.timeScale = 1;
        GameObject.Find("LevelManager").GetComponent<LevelControl>().NextLevel();
        endOfLevelCanvasObject.SetActive(false);
    }



}
