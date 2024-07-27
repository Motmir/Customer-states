using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : MonoBehaviour
{
    private const int interactCooldown = 2;
    private float remainingCooldown = 0;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (remainingCooldown > 0) {
            remainingCooldown -= Time.deltaTime;
        }
    }

    public void Screwdriver(){
        if (remainingCooldown >= 0) {
            remainingCooldown = interactCooldown;
            Debug.Log(this.name);
        }
        
    }
    public void Blowtorch(){
        if (remainingCooldown >= 0) {
            remainingCooldown = interactCooldown;
            Debug.Log(this.name);
        }    
    }
}
