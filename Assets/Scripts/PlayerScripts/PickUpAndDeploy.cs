using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDeploy : MonoBehaviour
{

    // R for picking up / deploying the animal
    private bool hasAnimal;

    private GameObject animal;

    private bool canPickUp;


    //TODO: Leave Animal in the direction Robot is facing


    // Start is called before the first frame update
    void Start()
    {
        // Start the level with the animal on the back
        hasAnimal = true;

        // Get a reference to the animal
        // should be a child of the robot
        animal = GameObject.FindGameObjectWithTag("Animal");
        animal.GetComponent<Rigidbody2D>().gravityScale = 0;
        animal.GetComponent<Collider2D>().enabled = false;
    }


    

    // Update is called once per frame
    void Update()
    {
        if (hasAnimal)
        {
            animal.transform.position = transform.position + (Vector3.up + Vector3.left) * 0.5f;

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Dropped");
                animal.transform.parent = null;
                animal.transform.position = transform.position + Vector3.right;
                animal.GetComponent<Rigidbody2D>().gravityScale = 1;
                animal.GetComponent<Collider2D>().enabled = true;
                hasAnimal = false;
            }
        }
        
        if (!hasAnimal && canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Picked Up");
                animal.transform.parent = gameObject.transform;
                animal.transform.position = transform.position + Vector3.up + Vector3.left;
                animal.GetComponent<Rigidbody2D>().gravityScale = 0;
                animal.GetComponent<Collider2D>().enabled = false;
                hasAnimal = true;
                canPickUp = false;
            }
        }

        if (!hasAnimal)
            canPickUp = Physics2D.OverlapCircle(gameObject.GetComponent<Rigidbody2D>().position, 1.5f, LayerMask.GetMask("Animal"));

    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Animal")
    //    {
    //        canPickUp = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Animal")
    //    {
    //        canPickUp = false;
    //    }
    //}
}
