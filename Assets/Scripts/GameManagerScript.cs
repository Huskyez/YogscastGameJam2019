using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public string LevelToLoad;

    //public GameObject EndPositionRobot;
    //public GameObject EndPositionAnimal;


    private GameObject animal;
    private GameObject robot;

    //public GameObject PauseMenu;
    public GameObject PauseMenuInstance;
    private bool isPaused = false;

    public bool IsAtExitAnimal { set; get; }
    public bool IsAtExitRobot { set; get; }

    //public float CheckCollisionDistance;

    // Start is called before the first frame update
    void Start()
    {

        //PauseMenuInstance = GameObject.FindGameObjectWithTag("PauseMenu");

        if (PauseMenuInstance == null)
        {
            Debug.LogError("Pause Menu is NULL");
        }
        PauseMenuInstance.SetActive(false);

        //animal = GameObject.FindGameObjectWithTag("Animal");
        //robot = GameObject.FindGameObjectWithTag("Robot");
    }

    // Update is called once per frame
    void Update()
    {

        if (IsAtExitRobot && IsAtExitAnimal)
        {
            Debug.Log("CHANGE LEVEL TO " + LevelToLoad);
            SceneManager.LoadScene(LevelToLoad);           

        }

        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                PauseMenuInstance.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }


    // ------------------------------ UI CONTROLLER ----------------------------------------------------------------------------------------

    public void PlayGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenuInstance.SetActive(false);
    }

    public void ReloadGame()
    {

        Debug.Log(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
