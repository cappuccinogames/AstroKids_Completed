using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager2 : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver = false;
    private bool _isQuestComplete = false;
    private bool _once;

    private void Start()
    {
        PlayerPrefs.SetInt("ActiveScene", SceneManager.GetActiveScene().buildIndex);      
        // Debug.Log("start:" + PlayerPrefs.GetInt("ActiveScene"));

    }
    public void GameOver()
    {
        _isGameOver = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //0 = current game scene
        }

        if(_isQuestComplete && _once)
        {
            StartCoroutine(DelayForSceneTrans());
            _once = false;

        }
    }
    public void QuestComplete()
    {
        _isQuestComplete = true;
        _once = true;
    }

    IEnumerator DelayForSceneTrans()
    {
        PlayerPrefs.DeleteKey("ActiveScene");
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene(0);

    }
}
