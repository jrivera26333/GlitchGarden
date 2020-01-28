using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour //Stores selected defender and toggles between off and on
{

    [SerializeField] Defender defenderPrefab; //We are setting the button to this object

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.Log(name + " has no cost text, add some!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown() //With OnMouseDown you need to make sure the objects have colliders
    {
        var buttons = FindObjectsOfType<DefenderButton>(); //Find all the objects of this type

        foreach(DefenderButton button in buttons) //Turn all buttons blacks then turn the clicked button white.
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255); //This is black
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab); //We grab the spawner script and then send in the defenderPrefab of type Defender
    }
}
