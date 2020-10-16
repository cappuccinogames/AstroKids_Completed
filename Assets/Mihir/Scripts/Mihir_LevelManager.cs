using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Mihir_LevelManager : MonoBehaviour
{
    public static Mihir_LevelManager Instance;

    public float levelTime;

    private bool endLevel = false;

    private bool restart = false;

    public int level;

    public GameObject correctText;





    public float barLeftEnd;
    public float barRightEnd;
    public float barSpeed;


    [SerializeField]
    public GameObject TravelledDistance;
    [SerializeField]
    private GameObject TotalDistance;
    private Renderer rend;

    public Text levelText;


   
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //setting the level + leveltime for the first level
        levelTime = 20f;
        level = 1;
        //calculating the length and position of the bar
        float barScaleX = levelTime / 10;
        float barPosX = (.5f * barScaleX) - 6;



        TotalDistance.transform.localScale = new Vector3(barScaleX, TotalDistance.transform.localScale.y, TotalDistance.transform.localScale.z);
        //TotalDistance.transform.position = new Vector3(barPosX, TotalDistance.transform.position.y, TotalDistance.transform.position.z);

        rend = TotalDistance.GetComponent<Renderer>();
        barLeftEnd = rend.bounds.min.x;
        barRightEnd = rend.bounds.max.x;

        //reseting the marker to the left end of the bar
        TravelledDistance.transform.position = new Vector3(barLeftEnd, TravelledDistance.transform.position.y, TravelledDistance.transform.position.z);

        TotalDistance.gameObject.SetActive(true);
        TravelledDistance.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    private void Start()
    {
       


        correctText.SetActive(false);
            level = PlayerPrefs.GetInt("MihirsLevel");

        if (level == 0)
            level = 1;

            levelText.text = "Level: " + level.ToString();

           PlayerPrefs.SetInt("ActiveScene", SceneManager.GetActiveScene().buildIndex);
       

        //Debug.Log("level: " + level);
       // Debug.Log(PlayerPrefs.GetInt("ActiveScene"));
    }
    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Mihir_Game")
        {
            //resetting the marker on the bar
            TravelledDistance.transform.position = new Vector3(barLeftEnd, TravelledDistance.transform.position.y, TravelledDistance.transform.position.z);
    
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("level " + level);

            //changing the leveltime based on which level is the current
            if (level == 2)
            {
                levelTime = 20f;
            }
            else if (level == 3)
            {
                levelTime = 20f;
            }
            else if (level == 4)
            {
                levelTime = 20f;
            }
            else if (level == 5)
            {
                levelTime = 30f;
            }
            else if (level == 6)
            {
                levelTime = 30f;
            }
            else if (level == 7)
            {
                levelTime = 35f;
            }
            else if (level == 8)
            {
                levelTime = 40f;
            }


            //re-calculating the bar
            float barScaleX = levelTime / 10;
            float barPosX = (.5f * barScaleX) - 6;

            TotalDistance.transform.localScale = new Vector3(barScaleX, TotalDistance.transform.localScale.y, TotalDistance.transform.localScale.z);
            TotalDistance.transform.position = new Vector3(barPosX, TotalDistance.transform.position.y, TotalDistance.transform.position.z);

            rend = TotalDistance.GetComponent<Renderer>();
            barLeftEnd = rend.bounds.min.x;
            barRightEnd = rend.bounds.max.x;

            TotalDistance.gameObject.SetActive(true);
            TravelledDistance.gameObject.SetActive(true);
        }


        if (endLevel == true)
        {
            //SceneManager.LoadScene("Mihir_PlanetInfo");
            if(level<8 && !restart)
            {
                level++;
                PlayerPrefs.SetInt("MihirsLevel", level);
               

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (level==8)
            {
                PlayerPrefs.SetInt("MihirsLevel", 1);
                // PlayerPrefs.SetInt("MihirsLevel", 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
           

            //endLevel = false;

        }
        


        if (restart == true)
        {
            //restarting a level by loading the scene again and moving the marker
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            TravelledDistance.transform.position = new Vector3(barLeftEnd, TravelledDistance.transform.position.y, TravelledDistance.transform.position.z);
            restart = false;
        }


    }


    public void finishLevel()
    {

        if (level<=8)
        {

            StartCoroutine(DelayForNextLevel());
            
        }

    }

    public void restartLevel()
    {
        restart = true;

    }

    IEnumerator DelayForNextLevel()
    {
        correctText.SetActive(true);
        yield return new WaitForSeconds(2f);
        endLevel = true;
    }


}
