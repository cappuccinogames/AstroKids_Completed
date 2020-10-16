using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
    public int gamemode;
    //private int stage = 1;
    bool finishedlanding = false;
    bool delayForNext;
    [SerializeField]
    private Text gameover;
    [SerializeField]
    private Text landing;

    private SpawnManager _forstar;

    private planet_surface _landing;

    private player _player;

    private moveBar _tap;

    [SerializeField]
    private AudioSource _win;

    [SerializeField]
    private AudioSource _lose;

    //[SerializeField]
    //private AudioClip lose;

    // Start is called before the first frame update
    public void Start()
    {

        gamemode = 0;

        PlayerPrefs.SetInt("ActiveScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(PlayerPrefs.GetInt("ActiveScene"));
        //text invisible at first
        gameover.gameObject.SetActive(false);
        landing.gameObject.SetActive(false);

        _forstar = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _landing = GameObject.Find("planet_surface").GetComponent<planet_surface>();
        _tap = GameObject.Find("moveBar").GetComponent<moveBar>();
        _player = GameObject.Find("player").GetComponent<player>();

        // _win = GetComponent<AudioSource>();
        //_lose = GetComponent<AudioSource>();

        delayForNext = false;
    }
  /*  void Changestage()
    {
        if (stage == 0)
        {
            SceneManager.LoadScene("Mercury");
        }
        else if (stage == 1)
        {
            SceneManager.LoadScene("Venus");
        }
        else if (stage == 2)
        {
            SceneManager.LoadScene("Moon");
        }
        else if (stage == 3)
        {
            SceneManager.LoadScene("Mars");
        }
        else if (stage == 4)
        {
            SceneManager.LoadScene("Jupiter");
        }
        else if (stage == 5)
        {
            SceneManager.LoadScene("Saturn");
        }
        else if (stage == 6)
        {
            SceneManager.LoadScene("Uranus");
        }
        else if (stage == 7)
        {
            SceneManager.LoadScene("Neptune");
        }
    }*/

    // Update is called once per frame
    void Update()
    {
       
        //regular gamemode
        if (gamemode == 0)
        {
            _tap.TapTime();
        }

        //lose
        else if (gamemode == 1)
        {
            gameover.gameObject.SetActive(true);
            _forstar.ActionDone();
            _player.stopTrail();

            //replace with tap
            if (Input.GetMouseButtonDown(0) && gamemode ==1) //if (Input.GetKeyDown(KeyCode.R)|| Input.touchCount == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
            }
        }
        //win
        else if (gamemode == 2)
        {
            landing.gameObject.SetActive(true);
            _forstar.ActionDone();
            _landing.landing();
             _player.stopTrail();

            
            
            //this is only for testing, will delete

            if (finishedlanding && gamemode==2 && delayForNext) //if (Input.GetKeyDown(KeyCode.N) && finishedlanding==true)
            {
  
               
                /* if (stage != 7)
                 {
                     stage++;
                 }*/

                //if (SceneManager.GetActiveScene().name == "Mercury")
                //{
                //    SceneManager.LoadScene("Venus");
                //}
                //else if (SceneManager.GetActiveScene().name == "Venus")
                //{

                //    SceneManager.LoadScene("Moon");
                //}
                //else if (SceneManager.GetActiveScene().name == "Moon")
                //{
                //    SceneManager.LoadScene("Mars");
                //}
                //else if (SceneManager.GetActiveScene().name == "Mars")
                //{
                //    SceneManager.LoadScene("Jupiter");
                //}
                //else if (SceneManager.GetActiveScene().name == "Jupiter")
                //{
                //    SceneManager.LoadScene("Saturn");
                //}
                //else if (SceneManager.GetActiveScene().name == "Saturn")
                //{
                //    SceneManager.LoadScene("Uranus");
                //}
                //else if (SceneManager.GetActiveScene().name == "Uranus")
                //{
                //    SceneManager.LoadScene("Neptune");
                //  }
                

               
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
               

                    


            }
            //this is only for testing, will delete
            //else if (Input.GetKeyDown(KeyCode.P))
            //{

            //  /*  if (stage != 0)
              
            //    {
            //        stage--;
            //    }*/
                
            //    if (SceneManager.GetActiveScene().name == "Venus")
            //    {
            //        SceneManager.LoadScene("Mercury");
            //    }
            //    if (SceneManager.GetActiveScene().name == "Moon")
            //    {
            //        SceneManager.LoadScene("Venus");
            //    }
            //    if (SceneManager.GetActiveScene().name == "Neptune")
            //    {
            //        SceneManager.LoadScene("Uranus");
            //    }
            //    if (SceneManager.GetActiveScene().name == "Mars")
            //    {
            //        SceneManager.LoadScene("Moon");
            //    }
            //    if (SceneManager.GetActiveScene().name == "Jupiter")
            //    {
            //        SceneManager.LoadScene("Mars");
            //    }
            //    if (SceneManager.GetActiveScene().name == "Saturn")
            //    {
            //        SceneManager.LoadScene("Jupiter");
            //    }
              
                
            //}

          

        }

    }


    public void lose()
    {
        _lose.Play();
        gamemode = 1;

    }

    public void win()
    {
        _win.Play();


        StartCoroutine(DelayforTransition());
 

    }

    public void finland()
    {
        finishedlanding = true;
    }
    IEnumerator DelayforTransition()
    {
        gamemode = 2;
        yield return new WaitForSeconds(4f);
        delayForNext = true;
      
    }

}