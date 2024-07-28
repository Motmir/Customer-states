using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    [SerializeField] private Sprite screwEven;

    [SerializeField] private Sprite screwOdd;

    [SerializeField] private GameObject bolt;

    public void SetScrew(int level){
        if (level == 0) {
            bolt.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else {
            bolt.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Sprite sprite = (level % 2 == 0) ? screwEven : screwOdd;
            bolt.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            bolt.transform.position = this.transform.position + new Vector3(0f,0.03f*level,0f);
        }

    }
}
