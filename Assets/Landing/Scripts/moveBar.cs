using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class moveBar : MonoBehaviour
{
 
    [SerializeField]
    private float _speed = 7f;

    private GameManager _game;

    //private TapBar _bar;

    float greenArea1;
    float greenArea2;

    //float greenstart;
    //float greenend;

    void Start()
    {
        //starts at the beginning of the bar

       // transform.position = new Vector3(0f, 3.72f,-.1f);

        _game = GameObject.Find("GameManager").GetComponent<GameManager>();

        //GameObject bar = GameObject.Find("TapBar");
        //TapBar tapbar = bar.GetComponent<TapBar>();


        //_bar = GameObject.Find("TapBar").GetComponent<TapBar>();

        //greenstart = _bar.greenArea1;
        // greenend = _bar.greenArea2;

    }
   
    public void TapTime()
    {
        float rightBorder = 3.22f;
        float leftBorder = -3.22f;


      
        if ((transform.localPosition.x >= rightBorder) || (transform.localPosition.x <= leftBorder)) // we use "OR" 
        {
            //if we are out of bounds, we are changing the direction of the speed
            _speed *= -1f;
        }

        //calculate new position
        var newpos = transform.localPosition + Vector3.right * Time.deltaTime * _speed;

        //clamp the position in bounds
        newpos.x = Mathf.Clamp(newpos.x, leftBorder, rightBorder);
        transform.localPosition = newpos;

        StartCoroutine(DelayForNextTap());


    }


    IEnumerator DelayForNextTap()
    {
        yield return new WaitForSeconds(0.1f);
        if (SceneManager.GetActiveScene().name == "Mars" || SceneManager.GetActiveScene().name == "Moon")
        {
            greenArea1 = -0.5f;
            greenArea2 = 0.6f;
            if (Input.GetMouseButtonDown(0) && _speed != 0) //if (Input.GetKeyDown(KeyCode.Space)||Input.touchCount==1)
            {
                _speed = 0;

                if (transform.localPosition.x > greenArea1 && transform.localPosition.x < greenArea2)
                {

                    //play landing animation
                    _game.win();
                    Debug.Log("You Landed!");
                }
                else
                {
                    //play losing animation
                    Debug.Log("You Crashed!");
                    _game.lose();
                }


            }
        }

        else if (SceneManager.GetActiveScene().name == "Venus" || SceneManager.GetActiveScene().name == "Mercury")
        {
            greenArea1 = -0.9f;
            greenArea2 = 0.9f;
            if (Input.GetMouseButtonDown(0) && _speed != 0)// if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1)
            {
                _speed = 0;


                if (transform.localPosition.x > greenArea1 && transform.localPosition.x < greenArea2)
                {

                    //play landing animation
                    _game.win();
                    Debug.Log("You Landed!");
                }
                else
                {
                    //play losing animation
                    Debug.Log("You Crashed!");
                    _game.lose();
                }


            }
        }

        else if (SceneManager.GetActiveScene().name == "Jupiter")
        {
            greenArea1 = -1.5f;
            greenArea2 = 0f;
            if (Input.GetMouseButtonDown(0) && _speed != 0) //if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1)
            {
                _speed = 0;

                if (transform.localPosition.x > greenArea1 && transform.localPosition.x < greenArea2)
                {

                    //play landing animation
                    _game.win();
                    Debug.Log("You Landed!");
                }
                else
                {
                    //play losing animation
                    Debug.Log("You Crashed!");
                    _game.lose();
                }


            }
        }

        else if (SceneManager.GetActiveScene().name == "Saturn" || SceneManager.GetActiveScene().name == "Uranus")
        {
            greenArea1 = -0.3f;
            greenArea2 = 0.3f;
            if (Input.GetMouseButtonDown(0) && _speed != 0) //if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1)
            {
                _speed = 0;

                if (transform.localPosition.x > greenArea1 && transform.localPosition.x < greenArea2)
                {
                    //play landing animation

                    _game.win();
                    Debug.Log("You Landed!");
                }
                else
                {
                    //play losing animation
                    Debug.Log("You Crashed!");
                    _game.lose();
                }

            }
        }

        else if (SceneManager.GetActiveScene().name == "Neptune")
        {
            greenArea1 = 0.8f;
            greenArea2 = 1.6f;
            if (Input.GetMouseButtonDown(0) && _speed != 0) //if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1)
            {
                Debug.Log(transform.position);
                _speed = 0;

                if (transform.localPosition.x > greenArea1 && transform.localPosition.x < greenArea2)
                {

                    //play landing animation
                    _game.win();
                    Debug.Log("You Landed!");
                }
                else
                {
                    //play losing animation
                    Debug.Log("You Crashed!");
                    _game.lose();
                }


            }
        }

    }

}

