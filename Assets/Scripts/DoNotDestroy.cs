using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
   public int scene;

   private void Awake()
    {
        scene = SceneManager.GetActiveScene().buildIndex;

        if (scene == 0)
        {
            DontDestroyOnLoad(GameObject.Find("BackgroundMusic"));
        } 
        
        
        
        
       
    }
}
