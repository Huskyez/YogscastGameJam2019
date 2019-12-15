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

    [SerializeField]
    private bool inRange = false;

    private bool onLadder = false;


    private float delay = 0.5f;

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

        if (inRange)
        {
            if (slot.NrHands > 0)
            {
                if (moveScript.character == PlayerMove.PlayerCharacters.Animal)
                {
                    if (!onLadder)
                    {
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            transform.position += Vector3.left;
                        }
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            transform.position += Vector3.right;
                            // transform.Translate(Vector3.right * 4.5f * climbSpeed * Time.deltaTime);
                        }
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.LeftArrow))
                            transform.Translate((Vector3.down) * climbSpeed * Time.deltaTime);
                        if (Input.GetKey(KeyCode.RightArrow))
                            transform.Translate((Vector3.up) * climbSpeed * Time.deltaTime);
                    }

                    
                }
                else
                {
                    if (!onLadder)
                    {
                        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)) && delay < 0.0f)
                        {
                            transform.position += Vector3.left;
                            delay = 0.5f;
                        }
                        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) && delay < 0.0f)
                        { 
                            transform.position += Vector3.right;
                            delay = 0.5f;
                            // transform.Translate(Vector3.right * 4.5f * climbSpeed * Time.deltaTime);
                        }
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.S))
                            transform.Translate((Vector3.down) * climbSpeed * Time.deltaTime);
                        if (Input.GetKey(KeyCode.W))
                            transform.Translate((Vector3.up) * climbSpeed * Time.deltaTime);
                    }
                }
            }   
                
        }

        delay -= Time.deltaTime;

        if (!onLadder)
            inRange = Physics2D.Raycast(rb.position, Vector3.right, 1.1f, LayerMask.GetMask("Ladder")) || Physics2D.OverlapCircle(rb.position, 0.6f, LayerMask.GetMask("Ladder"));
        
        if (inRange)
        {
            moveScript.CanMove = false;
            rb.gravityScale = 0;
        }
        else
        {
            moveScript.CanMove = true;
            rb.gravityScale = 1;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            onLadder = false;
        }
    }

}
