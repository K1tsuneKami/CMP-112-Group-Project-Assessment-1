using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// MOST OF THIS WAS DONE BY MARTIN
// Comments have been done by Kyle

public class playerInput : MonoBehaviour
{
    // Variables for player input, notably speeds, jump stuff and direction
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float speed = 10;
    public float jumpSpeed;
    public float dashSpeed;
    public float acceleration;
    private bool hasJumped;
    private bool hasDashed;
    private bool movingLeft;
    private bool movingRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        acceleration = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Flips player sprite and moves in direction of key held
        if (Input.GetKeyDown("a"))
        {
            movingLeft = true;
            movingRight = false;
            spriteRenderer.flipX = true;
        }
        
        if (Input.GetKeyDown("d"))
        {
            movingRight = true;
            movingLeft = false;
            spriteRenderer.flipX = false;

        // Checks for dash and jump movement inputs
        }
        if (Input.GetKeyDown("space"))
        {
            hasJumped = true;
        }

        if (Input.GetKeyDown("left shift")) {
            hasDashed = true;
        }
        
    }

    void FixedUpdate()
    {
        // Gets horizontal movement speed
        float moveHoriz = Input.GetAxis("Horizontal");
        float xSpeed = moveHoriz * speed;
        rb.linearVelocityX = Mathf.MoveTowards(rb.linearVelocityX, xSpeed, acceleration);
        

        // Jump mechanic by applying force to rigidbody, then sets jump to false
        if (hasJumped == true)
        {
            Vector2 jump = new Vector2(0.0f, 1 * jumpSpeed);
            rb.AddForce(jump, ForceMode2D.Impulse);
            hasJumped = false;
        }


        // Dash mechanic by applying force to rigidbody directionally, then sets dash to false
        if (hasDashed)
        {
            Vector2 dash = new Vector2(dashSpeed, 0.0f);
            if (movingLeft)
            {

                rb.AddRelativeForce(-dash, ForceMode2D.Impulse);
                hasDashed = false;
            }
            else if (movingRight)
            {
                rb.AddRelativeForce(dash, ForceMode2D.Impulse);
                hasDashed = false;
            }
        }
    }


    // Destroys player object if they touch a trap
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }
}

