using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : MonoBehaviour
{
    private Robot robot;

    private const float interactCooldown = 0.5f;
    private float remainingCooldown = 0;
    // Start is called before the first frame update
    private int needBlowtorch = 0;
    private int needScrewdriver = 0;


    void Awake(){
        robot = this.transform.parent.gameObject.GetComponent<Robot>();
    }

    void FixedUpdate()
    {
        if (remainingCooldown > 0) {
            remainingCooldown -= Time.deltaTime;
        }
    }

    void Update()
    {
        if (needBlowtorch>0) {
            remainingCooldown -= Time.deltaTime;
        } else {

        }
    }

    public void Screwdriver(){
        if (remainingCooldown >= 0) {
            remainingCooldown = interactCooldown;
            if (needScrewdriver > 0){
                needScrewdriver -= 1;
            }
        }
        
    }
    public void Blowtorch(){
        if (remainingCooldown >= 0) {
            remainingCooldown = interactCooldown;
            if (needBlowtorch > 0){
                needBlowtorch -= 1;
            }
        }    
    }
}
