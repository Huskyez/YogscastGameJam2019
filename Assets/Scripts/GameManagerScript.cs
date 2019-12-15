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

    // Start is called before the first frame update
    void Start()
    { 

        if (PauseMenuInstance == null)
        {
            Debug.LogError("Pause Menu is NULL");
        }
        PauseMenuInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (IsAtExitRobot && IsAtExitAnimal)
        {
<<<<<<< HEAD
            if (LevelToLoad == "Final")
            {
                // TODO: add scripted shit
            }
            else
            {
                Debug.Log("CHANGE LEVEL TO " + LevelToLoad);
                SceneManager.LoadScene(LevelToLoad);

            }
=======
            Debug.Log("CHANGE LEVEL TO " + LevelToLoad);
            SceneManager.LoadScene(LevelToLoad);           

>>>>>>> forkyVersion
        }

        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("PAUSE");
                isPaused = true;
                PauseMenuInstance.SetActive(true);
                Time.timeScale = 0;
            }
<<<<<<< HEAD
=======

>>>>>>> forkyVersion
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

<<<<<<< HEAD
=======

>>>>>>> forkyVersion
    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenuInstance.SetActive(false);
    }

    public void ReloadGame()
    {
<<<<<<< HEAD
        Time.timeScale = 1;
=======

>>>>>>> forkyVersion
        Debug.Log(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
