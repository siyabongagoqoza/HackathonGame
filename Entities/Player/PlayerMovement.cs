using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player State used to manage player actions.
public enum PlayerState
{
    idle,
    walk,
    attack,
    defend,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public PlayerState currentState;
    public float speed;
    public float defendStat;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public Joystick joystick;
    public Transform spawnPoint;
    public GameObject gameOverScreen;
    public GameObject attackCol;
    public PlayerInventory playerInventory;
    public float testDamage;
    public float testKnocktime;

    void Start()
    {
        currentState = PlayerState.idle;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        // By default the player will face down
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = joystick.Horizontal;
        change.y = joystick.Vertical;

      
        
        /*
            If the defend button is hit it changes the playerstate to defend and starts the defend coroutine.
        */
        if (Input.GetButtonDown("defend") && currentState != PlayerState.defend && currentState != PlayerState.stagger)
        {
            currentState = PlayerState.defend;
            StartCoroutine(DefendCo(defendStat));
        }

        /*
            If the players state is either walk, idle, or defend it'll call the UpdateAnimatioAndMove method.
            This prevents the player animation or position from updating when the player is in stagger state.
        */
        if (currentState == PlayerState.walk || currentState == PlayerState.idle || currentState == PlayerState.defend)
        {
            UpdateAnimatonAndMove();
        }
    }

    /*
        This function recieves user input from the directional controls and updates the players position.
        This function also passes the values to the animator to adjust the players animation based of it's Vector3 co-ords.
    */
    void UpdateAnimatonAndMove()
    {
        if (change != Vector3.zero)
        {
            // This is responsible for changing the players idle direction
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            currentState = PlayerState.walk;
        }
        else
        {
            animator.SetBool("moving", false);
            currentState = PlayerState.idle;
        }
    }

    public void Attack()
    {
        // If the button is hit and the player is not already attacking attack will be true
        if (currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
    }

    // This method changes the players position.
    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }

    /*
        This function activates player knockback on enemy contact and also applies damage to the players health.
        It raises the player health signal, that updates the players inital health value that is re-set at runtime.
        If the players health is 0 or below it'll despawn the player.
    */
    public void Knock(float knockTime, float damage)
    {
        currentHealth.initialValue -= damage;
        //FindObjectOfType<AudioManager>().Play("PlayerHit");    

        // Raise will activate method belonging to it example play a sound when the user takes damage.
        playerHealthSignal.Raise();
        
        if (currentHealth.initialValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            //currentHealth.initialValue = 5;
            
            gameOverScreen.SetActive(true);
            this.gameObject.SetActive(false);
            
            //This sets new spawn point
            //this.transform.position = spawnPoint.position;
        }
    }

    ///
    /// Co-routine Section
    ///

    /*
        
    */
    private IEnumerator AttackCo()
    {
        //animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        attackCol.SetActive(true);
        animator.SetBool("attacking", true);
        yield return null;
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        attackCol.SetActive(false);
        animator.SetBool("attacking", false);
        currentState = PlayerState.idle;
    }

    // Handles when player gets attacked by enemy.
    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    // Handles when player attack button is active.
    private IEnumerator DefendCo(float defendPercentage)
    {
        yield return new WaitForSeconds(defendPercentage);
        currentState = PlayerState.idle;
        myRigidbody.velocity = Vector2.zero;
    }
}
