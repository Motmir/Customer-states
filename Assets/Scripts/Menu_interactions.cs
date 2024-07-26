using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_interactions : MonoBehaviour
{
    public void playGame ()
    {
        Debug.Log("Load1");
        SceneManager.LoadScene(1);
    }

    public void optionButton()
    {
        Debug.Log("Load3");
        SceneManager.LoadScene(3);
    }

    public void creditsMenu()
    {
        Debug.Log("Load4");
        SceneManager.LoadScene(4);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}