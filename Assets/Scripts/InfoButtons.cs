using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoButtons : MonoBehaviour
{
    private GameObject[] paperList;
    private int current;
    [SerializeField] private GameObject greet;
    [SerializeField] private GameObject infoOne;
    [SerializeField] private GameObject infoTwo;
    [SerializeField] private GameObject disclaimer;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject next;
    [SerializeField] private GameObject start;

    // Start is called before the first frame update
    void Start()
    {
        paperList = new GameObject[4];
        paperList[0] = greet;
        paperList[1] = infoOne;
        paperList[2] = infoTwo;
        paperList[3] = disclaimer;

        current = 0;
        
        paperList[current].SetActive(true);

        start.SetActive(false);

        back.SetActive(false);
    }

    public void nextButton()
    {
        paperList[current].SetActive(false);
        paperList[current + 1].SetActive(true);

        current++;

       
    }
    
    public void backButton()
    {
        paperList[current].SetActive(false);
        paperList[current - 1].SetActive(true);
        
        current--;

       
    }

    public void startButton()
    {
        SceneManager.LoadScene(1);
    }
    
    void Update()
    {
        if (current == 0)
        {
            back.SetActive(false);
        }

        if (current > 0)
        {
            back.SetActive(true);
        }

        if (current == 3)
        {
            start.SetActive(true);
            next.SetActive(false);
        }

        if (current < 3)
        {
            start.SetActive(false);
        }


    }
}
