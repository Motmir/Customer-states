using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : MonoBehaviour
{
    private Robot robot;
    public Sprite dirtSprite;
    private GameObject dirt;
    private GameObject hurt;
    private GameObject screw;



    private const float interactCooldown = 2f;
    private float remainingCooldown = 0;
    // Start is called before the first frame update
    private int isBroken = 6;
    public bool isDirty = true;
    private int isLoose = 6;



    void Awake(){
        robot = this.transform.parent.gameObject.GetComponent<Robot>();
        hurt = this.gameObject.transform.Find("hurt").gameObject;
        dirt = this.gameObject.transform.Find("dirt").gameObject;
        Transform screwTransform = this.gameObject.transform.Find("screw");
        if (screwTransform != null)
        {
            screw = screwTransform.gameObject;
        }
    }

    void FixedUpdate()
    {
        if (remainingCooldown > 0) {
            remainingCooldown -= Time.deltaTime;
        }
    }

    void Update()
    {
        Sprite sprite = this.GetComponent<SpriteRenderer>().sprite;
        hurt.GetComponent<SpriteMask>().sprite = sprite;
        dirt.GetComponent<SpriteMask>().sprite = sprite;
        hurt.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,isBroken/6);
        dirt.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,isDirty ? 1.0f : 0.0f);
        if (screw) {
            screw.GetComponent<Screw>().SetScrew(isLoose);
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
