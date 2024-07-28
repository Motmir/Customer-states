using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class wash : MonoBehaviour
{
    [SerializeField] public AudioSource washEffect;

    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("WashSound", 0.5f);
        Invoke("GameComplete", 1.1f);
    }

    private void WashSound()
    {
        washEffect.Play();
    }

    private void GameComplete()
    {
        GameObject wash = GameObject.Find("Wash");
        GameObject.Find("LevelManager").GetComponent<LevelControl>().robot.GetComponent<Robot>().Wash();
        wash.SetActive(false);
    }
}
