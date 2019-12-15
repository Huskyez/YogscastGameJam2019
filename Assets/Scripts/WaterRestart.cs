using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRestart : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal") || collision.gameObject.CompareTag("Robot"))
        {
            Time.timeScale = 0.5f;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().ReloadGame();
        }
    }
}
