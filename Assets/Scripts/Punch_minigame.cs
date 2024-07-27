using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Punch_minigame : MonoBehaviour
{
    [SerializeField] private InputAction punchAction;
    [SerializeField] private GameObject punchPrefab;
    private GameObject progressBar;
    private float progress;
    GameObject punch;

    private void OnEnable()
    {
        punchAction.Enable();
        progress = 0;
        progressBar = GameObject.Find("Bar");
        StartCoroutine(ChangeBarColor());
    }
    private void OnDisable()
    {
        punchAction.Disable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (progressBar.GetComponent<Image>().fillAmount < 1)
        {
            if (punchAction.triggered != false)
            {
                progress = 0.05f;
                ApplyForce();
            } else
            {
                progress = -0.003f;
            }
            
            progressBar.GetComponent<Image>().fillAmount += progress;
        } else
        {
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

        Invoke("RemovePunch", 0.2f);
    }

    public void RemovePunch()
    {
        Destroy(punch);
    }

    private void GameComplete()
    {
        GameObject minigame = GameObject.Find("Punch");
        minigame.SetActive(false);
    }
}
