using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerNote : MonoBehaviour
{

    [SerializeField] public GameObject customerNote;
    public void ShowNotes()
    {
        if (customerNote.activeSelf == true)
        {
            customerNote.SetActive(false);
            Time.timeScale = 1f;
        } else
        {
            Time.timeScale = 0f;
            customerNote.SetActive(true);
        }
    }
}
