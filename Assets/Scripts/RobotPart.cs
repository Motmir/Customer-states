using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : MonoBehaviour
{
    public enum Dirt {None, Bloody, Tires , Drawing, Oil}

    public enum Part {
        Head,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
    }
    [System.NonSerialized] public RobotSet set;
    public Part IAm;
    private Robot robot;
    public Sprite dirtSprite;
    SpriteRenderer spriteRenderer;
    private GameObject dirt;
    private GameObject hurt;
    private GameObject screw;
    private GameObject spark;
    private const float interactCooldown = 2f;
    private float remainingCooldown = 0;
    [System.NonSerialized] public int isBroken = 0;
    [System.NonSerialized] public bool isDirty = false;
    [System.NonSerialized] public int isLoose = 0;
    [System.NonSerialized] public bool isSparking = false;


    void Awake(){
        robot = this.transform.parent.gameObject.GetComponent<Robot>();
        hurt = this.gameObject.transform.Find("hurt").gameObject;
        dirt = this.gameObject.transform.Find("dirt").gameObject;
        spark = this.gameObject.transform.Find("bad spark").gameObject;
        Transform screwTransform = this.gameObject.transform.Find("screw");
        if (screwTransform != null)
        {
            screw = screwTransform.gameObject;
        }
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (remainingCooldown > 0) {
            remainingCooldown -= Time.deltaTime;
        }
    }

    void Update()
    {
        Sprite sprite = null;
        switch (IAm){
            case Part.Head:
                if(robot.on){
                    sprite = set.headOn;
                } else {
                    sprite = set.headOff;
                }
                break;
            case Part.Torso:
                if(robot.on){
                    sprite = set.torsoOn;
                } else {
                    sprite = set.torsoOff;
                }
                break;
            case Part.LeftArm:
                sprite = set.arm;
                break;
            case Part.RightArm:
                sprite = set.arm;
                break;
            case Part.LeftLeg:
                sprite = set.leg;
                break;
            case Part.RightLeg:
                sprite = set.leg;
                break;
        }


        spriteRenderer.sprite = sprite;
        
        if (screw) {
            screw.GetComponent<Screw>().SetScrew(isLoose);
        }
        hurt.GetComponent<SpriteMask>().sprite = sprite;
        dirt.GetComponent<SpriteMask>().sprite = sprite;
        hurt.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,isBroken/6);
        dirt.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,isDirty ? 1.0f : 0.0f);

        if (isSparking){
            spark.SetActive(true);
        } else {
            spark.SetActive(false);
        }
    }

    public void Screwdriver(){
        if (remainingCooldown >= 0) {
            remainingCooldown = interactCooldown;
            if (isLoose > 0){
                isLoose -= 1;
            }
        }
        
    }
    public void Blowtorch(){
        if (remainingCooldown >= 0) {
            remainingCooldown = interactCooldown;
            if (isBroken > 0){
                isBroken -= 1;
            }
        }    
    }
}
