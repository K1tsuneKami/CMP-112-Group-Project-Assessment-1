using UnityEngine;
using UnityEngine.UI;

public class MovingPlatform : MonoBehaviour
{

    // Stores the positions the platform will move between, and assigns a public variable the platforms speed
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 nextPosition;

    // On startup sets next position to point B
    void Start()
    {
        nextPosition = pointB.position;
    }
    
    void Update()
    {
        // Moves vector towards the new position
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);


        // When the platform position is the same as currently set next position, it will swap the set next position to the other, from A to B then B to A
        if (transform.position == nextPosition)
        {
            nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }

    // When the player touches the platform, the moving position will also be assigned to the player, so the player moves with the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    // When the player stops touching the platform, it will set the "moving position" to null, so the player no longer moves in the direction of the platform.
    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player"))

        {
            collision.gameObject.transform.parent = null;
        }
    }
}