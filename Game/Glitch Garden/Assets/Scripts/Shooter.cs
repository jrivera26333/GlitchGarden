using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gunPosition;
    AttackerSpawner myLaneSpawner;
    Animator animator; //We are grabbing the animator

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        CreateProjectileParent();
        SetLaneSpawner(); //Find the spawner with the same Y axis
        animator = GetComponent<Animator>(); //Grab our animator component which has our bool parameter which we set
    }

    private void Update()
    {
        if(IsAttackerInLane()) //We are checking if we have minions running through our lane through our myLaneSpawner position
        {
            animator.SetBool("isAttacking", true); //Toggle attack animation
        }
        else
        {
            animator.SetBool("isAttacking", false); //Toggle idle animation
        }
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!projectileParent) //If we do not Defenders in the heiarchy
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0) //This is checking to see if currently have children (monsters) running along this spawner
        {
            return false; //If we don't have any monsters send false
        }
        else //If we do have monsters running along the lane return true
        {
            return true; 
        }
    }

    private void SetLaneSpawner()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>(); //This creates an array of all the spawners

        foreach(var spawner in spawners) //We are checking all the spawners to see if any match the same y position
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon); //Mathf.Epsilon is a very small number and its making sure the difference is very small to make sure both positions at y are equal. We have to use Mathf.Abs because if not if we are in another lane you could get negative numbers

            if(isCloseEnough) //If we do have one that matches
            {
                myLaneSpawner = spawner; //Send that spawner to this variable
            }
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gunPosition.transform.position, Quaternion.identity); //We can also use transform.rotation which means no rotation just use the default
        newProjectile.transform.parent = projectileParent.transform;
    }
}
