using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{

    public enum PlayerCharacters 
    { 
        Robot,
        Animal
    }

    //The type of the character
    [SerializeField]
    private PlayerCharacters _character;
    public PlayerCharacters character { get { return _character; } }


    public float MoveSpeed;
    public float JumpSpeed;
    public float FallSpeed;
  

    private Vector3 moveVector;
    private Rigidbody2D rb;

    //Use can move for things like pause, checking if it has legs etc.
    public bool CanMove;
    private bool touchingGround = true;

    public LayerMask Ground;

    public float JumpHeight;
    public float TimeToJumpHeight;

    private float jumpGravity;
    private float jumpVelocity;
    private Vector2 stepMovement;

    private float checkRadius = 1.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        jumpGravity = -(2 * JumpHeight) / Mathf.Pow(TimeToJumpHeight, 2);
        jumpVelocity = Mathf.Abs(jumpGravity) * TimeToJumpHeight;

    }

    private void FixedUpdate()
    {

        if (!CanMove)
            return;

        // Step update
        stepMovement = (rb.velocity + Vector2.up * Physics2D.gravity.y * Time.deltaTime * 0.5f) * Time.deltaTime;
        transform.Translate(stepMovement);
        rb.velocity += Physics2D.gravity * Time.deltaTime;



        if (character == PlayerCharacters.Robot)
        {
            if (Input.GetKey(KeyCode.A))
            {

                //Move the robot to the left
                moveVector = Vector3.left;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                //Move the robot to the right
                moveVector = Vector3.right;
            }

            if (Input.GetKeyDown(KeyCode.W) && touchingGround)
            { 
                // When jump button pressed,
                rb.velocity = new Vector2(0, jumpVelocity);

            }
        }


        if (character == PlayerCharacters.Animal)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Move the animal to the left
                moveVector = Vector3.left;
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //Move the animal to the right
                moveVector = Vector3.right;

            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && touchingGround)
            { 
                // When jump button pressed,
                rb.velocity = new Vector2(0, jumpVelocity);

            }

        }

        touchingGround = Physics2D.OverlapCircle(rb.position, checkRadius, Ground);

        transform.Translate(moveVector * MoveSpeed * Time.deltaTime);
        moveVector = Vector3.zero;

        // Code for faster falling
        if (rb.velocity.y < 0.0f)
        {
            rb.velocity += Vector2.up * FallSpeed * Time.deltaTime * Physics2D.gravity.y;
        }

    }
}
