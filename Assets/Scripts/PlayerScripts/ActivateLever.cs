using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLever : MonoBehaviour
{

    private bool canPull = false;
    private GameObject lever;
    private float wait = 0.5f;


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
                    Debug.Log("Lever Activated from: " + gameObject.name);
                    bool isActivated = lever.GetComponent<LeverActivation>().IsActivated;
                    lever.GetComponent<LeverActivation>().IsActivated = !isActivated;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Lever"))
        {
            canPull = true;
            lever = collider.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Lever"))
        {
            canPull = false;
            lever = null;
        }
    }
}
