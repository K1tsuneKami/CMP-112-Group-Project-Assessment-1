using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collection : MonoBehaviour
{

    // Function that triggers collect function when Player collides with pickup prefab 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        IItem item = collision.GetComponent<IItem>();

        //Makes sure there is an item
        if (item != null)
        {
            item.Collect();  
        }
    }
}