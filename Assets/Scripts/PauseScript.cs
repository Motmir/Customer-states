using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject bookBackground;
    [SerializeField] private GameObject menuB;
    [SerializeField] private GameObject settingsB;
    [SerializeField] private GameObject helpB;
    [SerializeField] private GameObject backB;
    [SerializeField] private GameObject team;
    [SerializeField] private GameObject helpText;



    public void pauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

    }

    public void menuButton()
    {
        Application.Quit();
    }

    public void settingsButton()
    {
        SceneManager.LoadScene(4);
    }

    public void backButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void helpButton()
    {
        menuB.SetActive(false);
        settingsB.SetActive(false);
        backB.SetActive(false);
        helpB.SetActive(false);
        team.SetActive(false);
        helpText.SetActive(true);


    }

    public void helpBack()
    {
        menuB.SetActive(true);
        settingsB.SetActive(true);
        backB.SetActive(true);
        helpB.SetActive(true);
        team.SetActive(true);
        helpText.SetActive(false);
    }
}