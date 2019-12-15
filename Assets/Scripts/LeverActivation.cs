﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{

    public GameObject[] ToActivate;
    public bool IsActivated {get; set;}
    private bool activeObjects = false;

    // Start is called before the first frame update
    void Start()
    {
        IsActivated = false;
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActivated && !activeObjects)
        {
            Activate();
            activeObjects = true;
<<<<<<< HEAD
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
=======

            gameObject.GetComponent<SpriteRenderer>().flipX = true;

>>>>>>> forkyVersion
        }
        else if (!IsActivated && activeObjects)
        {
            Deactivate();
            activeObjects = false;
<<<<<<< HEAD
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
=======

            gameObject.GetComponent<SpriteRenderer>().flipX = false;

>>>>>>> forkyVersion
        }
        
    }

    private void Activate()
    {
        foreach (var obj in ToActivate)
        {
            obj.SetActive(true);
        }
    }
    
    private void Deactivate()
    {
        foreach (var obj in ToActivate)
        {
            obj.SetActive(false);
        }
    }

}
