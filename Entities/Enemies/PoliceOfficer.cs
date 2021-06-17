using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script will inherit everything from the "Enemy.cs" script.
    This achieved by "public class PoliceOfficer : Enemy" as opposed to
    public class PoliceOfficer : MonoBehaviour
*/

public class PoliceOfficer : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public float attackAnimTime;
    

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("player").transform;
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        CheckEnemyAttack();
    }
    
    public void OnTriggerEnter2D(Collider2D other){
        

        if (other.gameObject.CompareTag("player")){
            StartCoroutine(ChangeAttackAnim(attackAnimTime));     
            Debug.Log("rinne");
        }
    }

     // Enemy Coroutine to change enemy attack animation
    private IEnumerator ChangeAttackAnim(float attackAnimTime){
        
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(attackAnimTime);
        anim.SetBool("attacking", false);
    }
        
    public void CheckEnemyAttack(){

        if (currentState == EnemyState.attack){
            Debug.Log("enemy is idle");
    }
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            /*
                This method is used to move the enemy towards the player.
                If the enemy is not staggered and the enemy is either in idle or walk state this condition will run.
                It calculates the distance bewtween the player and itself, it then moves closer to the player and changes it's state to walk.
            */
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("moving", true);
            }
        }else
        {
            // If the player is out of range the enemy will return to the idle state.
            ChangeState(EnemyState.idle);
            anim.SetBool("moving", false);
        }
        
    }

    // Method compares the state passed in to the current state. If the states are different it updates the state.
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    // This method is responsible for changing the float valuse in animator which in turn edit the animation.
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    

   


    private void changeAnim(Vector2 direction)
    {
        // The conditional loops checks which of the two variables are bigger.
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
}
