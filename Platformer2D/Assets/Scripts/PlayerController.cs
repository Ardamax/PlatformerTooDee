using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    private int extraJumps;
    public int extraJumpsValue;


    // sprite
    private bool facingRight = true;
    public Transform body;



    private void Start()
    {
        // get parent RigidBody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // called every physics step
    // used for regular updates such as adjusting physics objects (eg. RigidBody).
    private void FixedUpdate()
    {
        Move();

        //// flip sprite when direction changes
        //if (facingRight == false && moveInput > 0)
        //{
        //    Flip();
        //}
        //else if (facingRight == true && moveInput < 0)
        //{
        //    Flip();
        //}
    }

    // called every frame
    // used for receiving input, moving non-physics objects, simple timers
    private void Update()
    {

        Jump();
    }

    void Move()
    {
        // check for collision with ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded == true)
        {
            // reset jumps when grounded
            extraJumps = extraJumpsValue;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Jump")) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = body.localScale;
        Scaler.x *= -1;
        body.localScale = Scaler;
    }


}