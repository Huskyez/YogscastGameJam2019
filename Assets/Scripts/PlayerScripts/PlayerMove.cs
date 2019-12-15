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

    public enum Direction
    {
        left,
        right
    }
    
    public PlayerCharacters character;
    public Direction direction = Direction.right;


    public float MoveSpeed;
    public float JumpSpeed;
    public float FallSpeed;
  

    private Vector3 moveVector;
    private Rigidbody2D rb;

    private SpriteRenderer renderer;

    //Use can move for things like pause, checking if it has legs etc.
    public bool CanJump;
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
        renderer = GetComponent<SpriteRenderer>();
        
        jumpGravity = -(2 * JumpHeight) / Mathf.Pow(TimeToJumpHeight, 2);
        jumpVelocity = Mathf.Abs(jumpGravity) * TimeToJumpHeight;

    }

    private void FixedUpdate()
    {
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
                renderer.flipX = true;
                direction = Direction.left;


            }
            else if (Input.GetKey(KeyCode.D))
            {
                //Move the robot to the right
                moveVector = Vector3.right;
                renderer.flipX = false;
                direction = Direction.right;
            }

            if (CanJump)
            { 
                if (Input.GetKeyDown(KeyCode.W) && touchingGround)
                {
                    // When jump button pressed,
                    rb.velocity = new Vector2(0, jumpVelocity);

                }
            }
        }


        if (character == PlayerCharacters.Animal)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Move the animal to the left
                moveVector = Vector3.left;
                renderer.flipX = false;
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //Move the animal to the right
                moveVector = Vector3.right;
                renderer.flipX = true;

            }

            if (CanJump)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && touchingGround)
                {
                    // When jump button pressed,
                    rb.velocity = new Vector2(0, jumpVelocity);

                }
            }

        }

        touchingGround = Physics2D.Raycast(rb.position, Vector2.down, 1.0f, Ground);

        transform.Translate(moveVector * MoveSpeed * Time.deltaTime);
        moveVector = Vector3.zero;

        // Code for faster falling
        //if (rb.velocity.y < 0.0f)
        //{
        //    rb.velocity += Vector2.up * FallSpeed * Time.deltaTime * Physics2D.gravity.y;
        //}

    }
}
