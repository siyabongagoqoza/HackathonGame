using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI feature of Unity

// This script will be added to the sign object in Unity

public class Sign : Interactable
{/*
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is in range when E is pressed
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            // If the user presses E it disables the sign
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else // If the user presses E it enables the sign
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if other is "Player". collision box
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if other is "Player". collision box
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
    */
}
