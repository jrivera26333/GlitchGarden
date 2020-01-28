using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //The reason we do this in code is because we want to share this code and adjust it easily rather then doing it all throug animations. Translate ignores collisions so we are using a trigger
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>(); //Grabbing the health script attached to the object we collided with
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health) //If its an attack and has a health component to the damage. Also we don't want these cactus to be hitting each other and doing damage to themselves
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
