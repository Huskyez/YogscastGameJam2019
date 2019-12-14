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

    public bool IsAtExitAnimal { set; get; }
    public bool IsAtExitRobot { set; get; }

    //public float CheckCollisionDistance;

    // Start is called before the first frame update
    void Start()
    {
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


    public void ReloadGame()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
