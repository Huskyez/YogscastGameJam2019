using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectSlot))]
public class GiveBodyPart : MonoBehaviour
{

    private bool canGive = false;

    // How many parts can be given
    // must be set per level
    public int Count;

    private List<Transform> hands = new List<Transform>();
    private List<Transform> legs = new List<Transform>();
    private ObjectSlot slot;

    private Transform animal;
    //private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        slot = GetComponent<ObjectSlot>();

        animal = GameObject.FindGameObjectWithTag("Animal").transform;

    }

    // Update is called once per frame
    void Update()
    {
        canGive = Physics2D.OverlapCircle(gameObject.GetComponent<Rigidbody2D>().position, 1.5f, LayerMask.GetMask("Animal"));
        
        if (canGive && Count > 0)
        {
            //Give leg
            if (Input.GetKeyDown(KeyCode.G))
            {
            
                if(slot.NrLegs > 0)
                {
                    foreach (Transform trans in slot.heldObjects)
                    {

                        if (trans.tag == "Leg")
                        {
                            legs.Add(trans);

                        }
                    }

                    if (legs != null)
                    {
                        legs[0].SetParent(animal);
                        List<Transform> animalHeldObjects = animal.GetComponent<ObjectSlot>().heldObjects;
                        
                        if (animalHeldObjects == null)
                        {
                            Debug.LogError("IS NULL");
                        }

                        if (animalHeldObjects.Count == 0)
                        {
                            animalHeldObjects.Add(legs[0]);
                        }
                        else
                        {
                            animalHeldObjects[0] = legs[0];
                        }
                        slot.heldObjects.Remove(legs[0]);
                        Debug.Log("Leg given");
                        Count--;
                    }
                }

            }

            //Give hand 
            if (Input.GetKeyDown(KeyCode.F))
            {

                if (slot.NrHands > 0)
                {
                    foreach (Transform trans in slot.heldObjects)
                    {
                        if (trans.tag == "Hand")
                        {
                            hands.Add(trans);

                        }
                    }
                    if (hands != null)
                    {
                        hands[0].SetParent(animal);
                        List<Transform> animalHeldObjects = animal.GetComponent<ObjectSlot>().heldObjects;

                        if (animalHeldObjects == null)
                        {
                            Debug.LogError("IS NULL");
                        }

                        if (animalHeldObjects.Count == 0)
                        {
                            animalHeldObjects.Add(hands[0]);
                        }
                        else
                        {
                            animalHeldObjects[0] = hands[0];
                        }
                        slot.heldObjects.Remove(hands[0]);
                        Debug.Log("Hand given");
                        Count--;
                    }
                }

            }
        }

    }
}
