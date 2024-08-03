using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerNote : MonoBehaviour
{

    [SerializeField] public GameObject customerNote;
    [SerializeField] public GameObject customerStatesText;
    public void ShowNotes()
    {
        if (customerNote.activeSelf == true)
        {
            customerStatesText.GetComponent<TextMeshProUGUI>().text = "Open Customer Note";
            customerNote.SetActive(false);
            Time.timeScale = 1f;
        } else
        {
            customerStatesText.GetComponent<TextMeshProUGUI>().text = "Close Customer Note";
            Time.timeScale = 0f;
            customerNote.SetActive(true);
        }
    }
}
