using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    // Variables for a progress bar
    int progressAmount;
    public Slider progressBar;


    //Setting initial values for the progress bar
    void Start()
    {
        progressAmount = 0;
        progressBar.value = 0;
        Pickup.OnPickupCollect += IncreaseProgressAmount;
    }

    //Fills up progress bar when above condition is met, on pickup of a Pickup prefab
    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressBar.value = progressAmount;

    }

}