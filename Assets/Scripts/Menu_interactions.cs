using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_interactions : MonoBehaviour
{
  

    public void playGame()
    {
        SceneManager.LoadScene(5);
        
    }

    public void optionButton()
    {
        SceneManager.LoadScene(4);
    }

    public void creditsMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

}