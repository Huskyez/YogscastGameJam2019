using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectSlot))]
public class PlayerClimb : MonoBehaviour
{
    [SerializeField]
    private float climbSpeed;

    private ObjectSlot slot;
    private Rigidbody2D rb;
    private PlayerMove moveScript;

    private bool onLadder = false;
    

    // Start is called before the first frame update
    void Start()
    {
        slot = GetComponent<ObjectSlot>();
        rb = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMove>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (onLadder)
        {

            if(slot.NrHands > 0)
            {
                if (Input.GetKey(KeyCode.A))
                {

                    transform.Translate((Vector3.left + Vector3.up) * climbSpeed * Time.deltaTime);


                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate((Vector3.right + Vector3.up) * climbSpeed * Time.deltaTime);
                }
            }
                
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enters trigger");
        if(collision.tag == "Ladder")
        {
            moveScript.CanMove = false;
            rb.gravityScale = 0;
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {

            moveScript.CanMove = true;
            rb.gravityScale = 1;
            onLadder = false;
        }
    }

}
