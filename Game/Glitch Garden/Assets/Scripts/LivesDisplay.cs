﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    Text livesText;
    float lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty(); //We are subtracting the int value we get from our difficulty
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }


    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if(lives  <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
