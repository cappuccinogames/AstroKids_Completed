using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planet_surface : MonoBehaviour
{
    //speed of when it moves up
    private float _speed = 4f;

    private GameManager _game;

    void Start()
    {
        //start below the screen
        transform.position = new Vector3(0, -15f, 0);


        _game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Jupiter")
        {
            if (transform.position.y >= -.01f)
            {
                _game.finland();

            }
        }
        else
        {
           
            if (transform.position.y >= -3.74f)
            {

                _game.finland();

            }
        }

    }


    //when player lands, move this up
    public void landing()
    {
        if (SceneManager.GetActiveScene().name == "Jupiter")
        {
            if (transform.position.y <= 0)
            {
                transform.Translate(Vector2.up * _speed * Time.deltaTime);

            }


        }
        else
        {
            if (transform.position.y <= -2.75f)
            {
                transform.Translate(Vector2.up * _speed * Time.deltaTime);

            }
        }

       
    }
}
