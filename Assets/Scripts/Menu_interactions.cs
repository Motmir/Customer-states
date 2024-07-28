using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_interactions : MonoBehaviour
{
  

    public void playGame()
    {
        Debug.Log("Load5");
        SceneManager.LoadScene(5);
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Stop();
    }

    public void optionButton()
    {
        Debug.Log("Load4");
        SceneManager.LoadScene(4);
    }

    public void creditsMenu()
    {
        Debug.Log("Load3");
        SceneManager.LoadScene(3);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        Debug.Log("Load0");
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

}