using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    /*
        Thrust determines how far the entity will be knocked back.
        Knocktime determines how long the entity will remain in the knockback state.
        damage refers to the amount of damage that will be applied to the opposing entity.    

    */
    public float thrust;
    public float knockTime;
    public float damage;
    private Rigidbody2D entityRigidbody;
    private PlayerState entityState;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        /*
            This conditional loop runs if the entity is has a tag of "enemy" or "player".
        */
        entityRigidbody = GetComponent<Rigidbody2D>();

        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                /*
                    If the players state is not defend then knockbaclk will apply.
                    "other.GetComponent<PlayerMovement>().currentState" returns the players current state.
                */
                if (other.tag == "player" && other.GetComponent<PlayerMovement>().currentState != PlayerState.defend)
                {
                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);
                    
                    Debug.Log("Player is hitting/ enemy hit player");
                }
                

                /*
                    This condition runs in the instance the player attacks the enemy.
                    If the entities tag is enemy and it has a box collider that is a trigger this condition will activate.
                */
                if (entityRigidbody.gameObject.tag == "player" && other.gameObject.CompareTag("enemy") && other.isTrigger)
                {

                    entityState = GetComponent<PlayerMovement>().currentState;
//  coroutine here

                    // This function turns the enemies state to stagger which prevents all other movements.
                    // It then applies knockback force and damage to the entity/enemy.
                    if (entityState == PlayerState.attack)
                    {
                        hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                        other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                    }
                }

                // attackBox assigned to the attack colliders
                if (entityRigidbody.gameObject.tag == "attackBox" && other.gameObject.CompareTag("enemy") && other.isTrigger)
                {

                    GameObject life = transform.parent.gameObject;

                    if (life.tag == "player")
                    {
                        entityState = life.GetComponent<PlayerMovement>().currentState;


                        // This function turns the enemies state to stagger which prevents all other movements.
                        // It then applies knockback force and damage to the entity/enemy.
                        if (entityState == PlayerState.attack)
                        {
                             
                            hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                            other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                            
                        }
                    }
                }

                if (other.gameObject.CompareTag("player") && other.gameObject.tag != "zombie")
                {
                    /*
                        If the players state is not attack or defend this condition will run.
                        This function turns the players state to stagger which prevents all other movements.
                        It then applies knockback force and damage to the player.
                    */
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.attack && other.GetComponent<PlayerMovement>().currentState != PlayerState.defend)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                }
            }
        }
    }
} 

 