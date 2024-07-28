using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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

    private GameObject endOfLevelCanvas;
    private TextMeshPro scoreText;

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
        endOfLevelCanvas = GameObject.Find("EndOfLevelCanvas").gameObject;
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();

        scoreText.text = "Helllllllooooooo";
        endOfLevelCanvas.SetActive(true);
    }



}
