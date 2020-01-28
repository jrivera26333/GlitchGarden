using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned(); //Counts how many enemies have been spawned for our Level Controller
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>(); //Decreases the values of the remaining enemies
        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState(); //Once we destroy an object the lizard wont be colliding with anything and currentTarget will be null and thats what this is checking.
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false); //Toggling our animator parameter
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true); //Toggling our animator parameter
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) //Deals 20 damage as assigned in animator when isAttacking
    {
        if(!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
