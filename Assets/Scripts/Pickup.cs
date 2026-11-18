using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Pickup : MonoBehaviour, IItem
{
 
    public static event Action<int> OnPickupCollect;

    // Variable for pickup value
    public int worth = 10;

    // Collect function deletes pickup when collected, and gives pickups a numerical value
    public void Collect()
    {
        OnPickupCollect.Invoke(worth);
        Destroy(gameObject);
    }
}