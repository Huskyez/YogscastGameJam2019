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

    [SerializeField]
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
        if (slot.NrLegs == 0)
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
                                transform.position += Vector3.left * 0.5f;
                            }
                            if (Input.GetKeyDown(KeyCode.RightArrow))
                            {
                                transform.position += Vector3.right * 0.5f;
                            }
                        }
                        else
                        {
                            if (Input.GetKey(KeyCode.DownArrow))
                                transform.Translate((Vector3.down) * climbSpeed * Time.deltaTime);
                            if (Input.GetKey(KeyCode.UpArrow))
                                transform.Translate((Vector3.up) * climbSpeed * Time.deltaTime);
                        }


                    }
                    else
                    {
                        if (!onLadder)
                        {
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                transform.position += Vector3.left * 0.5f;
                            }
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                transform.position += Vector3.right * 0.5f;
                                // transform.Translate(Vector3.right * 4.5f * climbSpeed * Time.deltaTime);
                            }
                        }
                        else
                        {
                            if (Input.GetKey(KeyCode.S))
                                transform.Translate(Vector3.down * climbSpeed * Time.deltaTime);
                            if (Input.GetKey(KeyCode.W))
                                transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
                        }
                    }
                }
            }   
        }
        else 
        {
            if (slot.NrHands > 0)
                if (onLadder)
                {
                    if (Input.GetKey(KeyCode.S))
                        transform.Translate(Vector3.down * climbSpeed * Time.deltaTime);
                    if (Input.GetKey(KeyCode.W))
                        transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
                }
        }

        delay -= Time.deltaTime;

            inRange = Physics2D.Raycast(rb.position, Vector3.right, 1.0f, LayerMask.GetMask("Ladder"))
                    || Physics2D.OverlapCircle(rb.position, 0.6f, LayerMask.GetMask("Ladder"))
                    || Physics2D.Raycast(rb.position, Vector3.left, 1.0f, LayerMask.GetMask("Ladder"));


        if (inRange)
        {
            moveScript.CanJump = false;
            rb.gravityScale = 0;
        }
        else
        {
            moveScript.CanJump = true;
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
