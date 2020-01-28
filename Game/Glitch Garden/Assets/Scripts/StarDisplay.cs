using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour //Displays our current amount of stars and checks
{
    [SerializeField] int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount) //Checks our currents starts with the cost of the unity we want to spawn
    {
        return stars >= amount;
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount) //If we have more stars then we are subtracting, subtract the amount of stars.
        {
            stars -= amount;
            UpdateDisplay();
        }
        //Else if we don't have the right amount don't spend any stars
    }
}
