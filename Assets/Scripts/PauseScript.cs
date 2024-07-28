using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

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
}