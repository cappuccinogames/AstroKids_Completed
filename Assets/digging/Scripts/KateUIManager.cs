using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KateUIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Text _questCompleteText;

    public GameManager2 gameManager2;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _questCompleteText.gameObject.SetActive(false);
    }

    void GameOverSequence()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        gameManager2.GameOver();
    }
    public void PlayerDies()
    {
        GameOverSequence();
    }

    void QuestCompleteSequence()
    {
        _questCompleteText.gameObject.SetActive(true);
        gameManager2.QuestComplete();
    }

    public void PrizeCollect()
    {
        QuestCompleteSequence();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
