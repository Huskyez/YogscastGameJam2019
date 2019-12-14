using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExitType
{
    AnimalExit,
    RobotExit
}

public class ExitCollision : MonoBehaviour
{

    public ExitType type;

    private GameManagerScript gameManager;
    private string tagToCheck;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        if (gameManager == null)
        {
            Debug.LogError("Can not find GameManager");
        }

        if (type == ExitType.AnimalExit)
        {
            tagToCheck = "Animal";
        }
        else
        {
            tagToCheck = "Robot";
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == tagToCheck)
        {

            Debug.Log("Entering Collision");

            if (type == ExitType.AnimalExit)
            {
                gameManager.IsAtExitAnimal = true;
            }
            else
            {
                gameManager.IsAtExitRobot = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagToCheck)
        {

            Debug.Log("Exiting Collision");

            if (type == ExitType.AnimalExit)
            {
                gameManager.IsAtExitAnimal = false;
            }
            else
            {
                gameManager.IsAtExitRobot = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
