using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundedNPC : Interactable
{ 
    public Signal contextOn;
    public Signal contextOff;

    private Vector3 directionVector; // Allows the use of Vector 3 which contains x, y, and z co-ords.
    private Transform myTransform; // Imports the Transform component from the Unity Inspector.
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds; // This is the section where by the NPC will freely roam.

    // Relates to the NPC text/dialog
    public GameObject dialogBox; // Add the sprite relating to the dialog box.
    public Text dialogText; // Add the text container in the dialog box.
    public string dialog; // Allows the addition of custom text.

    private bool isMoving;

    // Relates to the NPC random movement effect
    private float moveTimeSeconds;
    private float waitTimeSeconds;
    public float minMoveTime;
    public float maxMoveTime;
    public float minWaitTime;
    public float maxWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            // Activate Dialog allows the player to open a dialog when in range of an NPC.
            
            contextOn.Raise();
        }
        else
        {
            contextOff.Raise();
            /*
                This function will activate if the bool isMoving = true.
                This will stop the NPC from moving once the player is range.
                Once the Player is out of range the Move() method will run activating random movement.
            */
            if (isMoving)
            {
                moveTimeSeconds -= Time.deltaTime;
                if (moveTimeSeconds <= 0)
                {
                    moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                    isMoving = false;
                }
                if (!playerInRange)
                {
                    Move();
                    dialogBox.SetActive(false);
                }
            }
            else
            {
                waitTimeSeconds -= Time.deltaTime;
                if (waitTimeSeconds <= 0)
                {
                    ChooseDifferentDirection();
                    isMoving = true;
                    waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                }
            }
        }
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;

        // Ensures that the NPC direction changes to prevent glitch.
        // Variable Loops ensure thay an infinte loop doesn't occur.
        while (temp == directionVector && loops < 100)
        {
            ChangeDirection();
            loops += 1;
        }
    }

    // This method allows the NPC's position to update in the game world.
    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    // This method uses a switch to randomly choose a dirction the NPC will move in/face.
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Walk to right
                directionVector = Vector3.right;
                break;
            case 1:
                // Walk to up
                directionVector = Vector3.up;
                break;
            case 2:
                // Walk to left
                directionVector = Vector3.left;
                break;
            case 3:
                // Walk to down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }

        UpdateAnimation();
    }

    // This method changes the NPC animation based on the direction it is going.
    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }


    // This makes sure the NPC will change direction when coming in contact with a box collider
    void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDifferentDirection();
    }

    /*
        If the player hits the interact button (Defined in Unity Input, "e") it enables the dialog box.
        If the dialog box is alredy active it'll deactivate it.
    */
    public void activateDialog() {
        if (playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                //FindObjectOfType<SoundManager>().Play("aye");
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
}
