using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCollision : MonoBehaviour
{

    
    private GameManagerScript gameManager;
    private string exitTag;


    private void Awake()
    {
        //gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();

        //if (type == ExitType.AnimalExit)
        //{
        //    exitTag = "AnimalExit";
        //}
        //else
        //{
        //    exitTag = "RobotExit";
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.gameObject.tag == exitTag)
    //    {
    //        if (type == ExitType.AnimalExit)
    //        {    
    //            gameManager.IsAtExitAnimal = true;
    //        }
    //        else
    //        {
    //            gameManager.IsAtExitRobot = true;
    //        }
    //    }
    //}

}
