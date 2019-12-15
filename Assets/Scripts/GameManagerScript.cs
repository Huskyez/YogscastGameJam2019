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
        else
        {
            PauseMenuInstance.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (IsAtExitRobot && IsAtExitAnimal)
        {
            if (LevelToLoad == "Final")
            {
                if (IsAtExitAnimal)
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
            else
            {
                Debug.Log("CHANGE LEVEL TO " + LevelToLoad);
                SceneManager.LoadScene(LevelToLoad);

            }
        }
        if (PauseMenuInstance != null)
            if (!isPaused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Debug.Log("PAUSE");
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
        Time.timeScale = 1;
        Debug.Log(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
