using UnityEngine;




public class Key : MonoBehaviour
{
    // Reference for door
    public GameObject door;

    // Checks for player collision on key, "collecting" the key and destroying the door
  private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(door);
            Destroy(gameObject);
        }
    }

}
