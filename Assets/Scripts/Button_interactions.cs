using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button_interactions : MonoBehaviour
{
    [SerializeField] private LevelControl manager;
    //public GameObject current_robot;
    public void Send_out()
    {
        manager.setDone();
    }

    public void Discard()
    {
        manager.DiscardDone();
    }
}
