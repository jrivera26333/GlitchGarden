using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour //This is for placing our objects on the map
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent) //If we do not Defenders in the heiarchy
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown() //This is a function already made by Unity. It requires that the click be on a collider
    {
        AttemptToPlaceDefenderAt(GetSquareClicked()); //We are calling the GetSquareClicked function so we can grab the cords to pass to the instantiation method.
    }

    public void SetSelectedDefender(Defender defenderToSelect) //We are calling this method from our DefenderButton so we can pass in what to instantiate
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClicked() //This is grabbing my mouse output
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //Raw position on the screen. We need to convert it to world cordinates.
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); //Converts a screen position to world space.
        Vector2 gridPos = SnapToGrid(worldPos);

        return gridPos;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>(); //This contains our information regarding how much stars we have to spend. Getting a reference
        int defenderCost = defender.GetStarCost(); //The defender here is the object button that is lit up in our 

        if(starDisplay.HaveEnoughStars(defenderCost)) //We are passing in the cost of the unit against how many stars we have
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) //Converting our float to our closest int
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos) //This is rounding my position placement
    {
        GameObject newDefender = Instantiate(defender.gameObject, roundedPos, Quaternion.identity); //I could do as Defender but I'd rather make it implicit and just call defender as a gameobject
        newDefender.transform.parent = defenderParent.transform; //The parent of this instantiated object is now defenderParent
    }
}
