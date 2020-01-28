using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour //Provides the cost of the unit
{
    [SerializeField] int startCost = 100;

    public void AddStars(int amount) //This is being called in the animator to constantly add stars
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return startCost;
    }
}
