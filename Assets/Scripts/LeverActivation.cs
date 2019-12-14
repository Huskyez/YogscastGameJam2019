using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{

    public GameObject[] ToActivate;
    public bool IsActivated {get; set;}
    private bool activeObjets = false;

    // Start is called before the first frame update
    void Start()
    {
        IsActivated = false;
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActivated && !activeObjets)
        {
            Activate();
            activeObjets = true;
        }
        else if (!IsActivated && activeObjets)
        {
            Deactivate();
            activeObjets = false;
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
