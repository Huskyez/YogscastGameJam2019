using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectSlot))]
public class GiveBodyPart : MonoBehaviour
{

    private bool canGive = false;

    private List<Transform> hands = new List<Transform>();
    private List<Transform> legs = new List<Transform>();
    private ObjectSlot slot;

    private Transform animal;
    //private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        slot = this.GetComponent<ObjectSlot>();

        animal = GameObject.FindGameObjectWithTag("Animal").transform;

    }

    // Update is called once per frame
    void Update()
    {

        
        if (canGive)
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
                    }
                    

                }

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Animal")
        {
            
            canGive = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Animal")
        {
            canGive = false;
        }
    }
}
