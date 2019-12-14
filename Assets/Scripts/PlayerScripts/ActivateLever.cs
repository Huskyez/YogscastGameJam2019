using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLever : MonoBehaviour
{

    private bool canPull = false;
    private GameObject lever;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPull)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (lever != null)
                {
                    //TODO: lever activate
                    Debug.Log("Lever Activated");
                    bool isActivated = lever.GetComponent<LeverActivation>().IsActivated;
                    lever.GetComponent<LeverActivation>().IsActivated = !isActivated;
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lever"))
        {
            canPull = true;
            lever = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lever"))
        {
            canPull = false;
            lever = null;
        }
    }
}
