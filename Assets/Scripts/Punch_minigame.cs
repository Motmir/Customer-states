using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Punch_minigame : MonoBehaviour
{
    [SerializeField] private InputAction punchAction;
    private GameObject progressBar;
    private float progress;
    private float punchTime;
    private Robot robot;
    private bool isDone;
    

    private void OnEnable()
    {
        isDone = false;
        punchAction.Enable();
        progress = 0;
        progressBar = GameObject.Find("Bar");
        robot = GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>();
        StartCoroutine(ChangeBarColor());
    }
    private void OnDisable()
    {
        punchAction.Disable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (progressBar.GetComponent<Image>().fillAmount < 1 && isDone == false)
        {
            if (punchAction.triggered != false)
            {
                progress = 0.05f;
                ApplyForce();
                robot.EnablePunch();
                punchTime = 0.3f;
                GetComponent<AudioSource>().Play();
                
            } else
            {
                progress = -0.003f;
            }
            punchTime -= Time.deltaTime;
            if (punchTime <= 0)
            {
                robot.DisablePunch();
            }
            progressBar.GetComponent<Image>().fillAmount += progress;
        } else
        {
            isDone = true;
            robot.DisablePunch();
            Invoke("GameComplete", 0.7f);
        }
    }
    
    private IEnumerator ChangeBarColor()
    {
        while (progressBar.GetComponent<Image>().fillAmount < 1)
        {
            progressBar.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, progressBar.GetComponent<Image>().fillAmount);
            yield return null;
        }
    }

    private void ApplyForce()
    {
        Rigidbody2D torso = GameObject.Find("torso").GetComponent<Rigidbody2D>();
        int option = Random.Range(1, 3);
        if (option == 1)
        {
            torso.velocity = Vector2.left * 5;

        }
        else if (option == 2)
        {
            torso.velocity = Vector2.right * 5;
        }
    }


    private void GameComplete()
    {
        this.gameObject.SetActive(false);
    }
}
