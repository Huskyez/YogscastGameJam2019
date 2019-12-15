using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove)), RequireComponent(typeof(ActivateLever))]
public class ObjectSlot : MonoBehaviour
{
    
    public List<Transform> heldObjects;
    
    private PlayerMove moveScript;
    private ActivateLever activateScript;
    private PlayerClimb climbScript;

    public Sprite[] RobotStates;
    public Sprite[] AnimalStates;

    private SpriteRenderer renderer;

    public int NrHands { get; set; }
    public int NrLegs { get; set; }

    
    private void Start()
    {

        moveScript = GetComponent<PlayerMove>();
        activateScript = GetComponent<ActivateLever>();
        climbScript = GetComponent<PlayerClimb>();

        renderer = GetComponent<SpriteRenderer>();

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

        if (NrHands > 0)
        {
            activateScript.enabled = true;
            climbScript.enabled = true;
        }
        else 
        {
            activateScript.enabled = false;
            climbScript.enabled = false;
        }

        changeSprites();
        
    }

    private void changeSprites()
    {
        if (gameObject.name == "Robot")
        {
            renderer.sprite = RobotStates[3 * NrHands + NrLegs]; 
        }

        if (gameObject.name == "Animal")
        {
            if (NrHands > 0)
            {
                renderer.sprite = AnimalStates[0];
            }
            if (NrLegs > 0)
            {
                renderer.sprite = AnimalStates[1];
            }
        }
    }
}
