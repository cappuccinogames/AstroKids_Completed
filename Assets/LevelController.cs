using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    int loadingScene;
    private void Start()
    {
        LoadScene();
    }

    void LoadScene()
    {
        PlayerPrefs.SetInt("CurrentScene", PlayerPrefs.GetInt("CurrenScene"));
        loadingScene = PlayerPrefs.GetInt("CurrenScene") + 1;
        SceneManager.LoadScene(loadingScene);
    }
}
