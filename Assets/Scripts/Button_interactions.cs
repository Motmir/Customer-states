using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button_interactions : MonoBehaviour
{
    [SerializeField] private LevelControl manager;
    //public GameObject current_robot;
    public void Send_out()
    {
        GameObject button = GameObject.Find("Send_out_button");
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -30);
        manager.setDone();
    }

    public void Discard()
    {
        GameObject button = GameObject.Find("Discard_button");
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -30);
        manager.DiscardDone();
    }
}
