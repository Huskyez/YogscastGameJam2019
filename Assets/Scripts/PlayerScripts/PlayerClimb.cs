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


    // Start is called before the first frame update
    void Start()
    {
        slot = GetComponent<ObjectSlot>();
        rb = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (onLadder && slot.NrHands > 0)
        {
            rb.velocity = Vector2.zero;
            
            if (moveScript.character == PlayerMove.PlayerCharacters.Animal)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                    rb.velocity = Vector2.down * climbSpeed;
                if (Input.GetKey(KeyCode.UpArrow))
                    rb.velocity = Vector2.up * climbSpeed;

                if (slot.NrLegs == 0)
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        rb.velocity = Vector2.left * climbSpeed;
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        rb.velocity = Vector2.right * climbSpeed;
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.S))
                    rb.velocity = Vector2.down * climbSpeed;
                if (Input.GetKey(KeyCode.W))
                    rb.velocity = Vector2.up * climbSpeed;

                if (slot.NrLegs == 0)
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        rb.velocity = Vector2.left * climbSpeed;
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        rb.velocity = Vector2.right * climbSpeed;
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            onLadder = true;
            moveScript.CanJump = false;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            onLadder = false;
            moveScript.CanJump = true;
            rb.gravityScale = 1;
        }
    }

}
