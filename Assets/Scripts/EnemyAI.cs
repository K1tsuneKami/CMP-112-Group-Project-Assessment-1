using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Variables for the enemy AI regarding movement and chase mechanic
    public Transform player;
    public float speed = 2f;
    public float jumpforce = 2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool onGround;
    private bool Jump;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //Check if the enemy is on the ground

        onGround = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // Gets the players current location 
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        // Checks if the player is above
        bool PlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, 1 << player.gameObject.layer);

        if (onGround)
        {
            // Sets a velocity for enemy to chase player
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

            // Checks if there is ground
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);

           // Checks if there is a gap ahead of it
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2f, groundLayer);

            // Checks if there is a platform above it
            RaycastHit2D PlatformAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, groundLayer);


            // Jumps when no there is no ground under
            if (!groundInFront.collider && !gapAhead.collider)
            {
                Jump = true;
            }

            // Also jumps when there is both a player and platform above
            else if (PlayerAbove && PlatformAbove.collider)
            {
                Jump = true;
            }

        }
    }
    private void FixedUpdate()
    {
        // Applies jump mechanic by adding directional force to enemy rigidbody
        if (onGround && Jump)
        {
            Jump = false;
            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 jumpDirection = direction * jumpforce;
            rb.AddForce(new Vector2(jumpDirection.x, jumpforce), ForceMode2D.Impulse);

        }
    }
}

