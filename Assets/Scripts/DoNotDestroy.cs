using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DoNotDestroy : MonoBehaviour
{

    

    private void Awake()
    {
       

        
            
        DontDestroyOnLoad(GameObject.Find("SoundEffects"));

        
        
        

       
       

        
           
    }    
}
    