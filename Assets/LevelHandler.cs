using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
  
    void Awake()
    {
        if(PlayerPrefs.GetInt("ActiveScene")==0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("ActiveScene")+1);
        }else
        {
  
            SceneManager.LoadScene(PlayerPrefs.GetInt("ActiveScene"));

        }

        //Debug.Log("activeScene: " + activeScene);

    }

   
}
 

