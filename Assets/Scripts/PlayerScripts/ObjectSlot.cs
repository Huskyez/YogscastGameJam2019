using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove)), RequireComponent(typeof(ActivateLever))]
public class ObjectSlot : MonoBehaviour
{
    
    public List<Transform> heldObjects;
    
    private PlayerMove moveScript;
    private ActivateLever activateScript;

    public int NrHands { get; set; }
    public int NrLegs { get; set; }

    
    private void Start()
    {

        moveScript = GetComponent<PlayerMove>();
        activateScript = GetComponent<ActivateLever>();

        moveScript.enabled = false;
        activateScript.enabled = false;

        heldObjects = new List<Transform>();


        List<Transform> allChildren = new List<Transform>(GetComponentsInChildren<Transform>());

        foreach (Transform trans in allChildren)
        {
            if (trans.CompareTag("Leg") || trans.CompareTag("Hand"))
            {
                heldObjects.Add(trans);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        NrLegs = 0;
        NrHands = 0;

        foreach (Transform go in heldObjects)
        {

            if (go.CompareTag("Leg"))
            {
                NrLegs += 1;
            }

            if (go.CompareTag("Hand"))
            {
                NrHands += 1;
            }

        }

        if (NrLegs > 0)
        {
            moveScript.enabled = true;
        }
        else
        {
            moveScript.enabled = false;
        }
<<<<<<< HEAD

        if (NrHands > 0)
        {
            activateScript.enabled = true;
        }
        else 
        {
            activateScript.enabled = false;
        }

        //Animal handling
        //if (moveScript.character == PlayerMove.PlayerCharacters.Animal)
        //{
            
        //    //Only check first object for the animal cause he can only carry one
        //    if (heldObjects[0].tag == "Leg")
        //    {
               
        //        moveScript.enabled = true;
        //    }

        //    else
        //    {
                
        //        moveScript.enabled = false;
        //    }

        //}

        ////Robot handling 
        //if(moveScript.character == PlayerMove.PlayerCharacters.Robot)
        //{
        //    NrLegs = 0;
        //    NrHands = 0;

        //    foreach (Transform go in heldObjects)
        //    {
                
        //        if (go.tag == "Leg")
        //        {
      
        //            NrLegs += 1;
                    
        //        }

        //        if(go.tag == "Hand")
        //        {

        //            NrHands += 1;
        //        }
                
        //    }
            
        //    if ( NrLegs > 0)
        //    {
        //        moveScript.enabled = true;
        //    }
        //    else
        //    {
        //        moveScript.enabled = false;
        //    }

        //    //Here comes the hand

        //}
=======
>>>>>>> forkyVersion
        
    }
}
