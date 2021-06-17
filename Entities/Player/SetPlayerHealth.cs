using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerHealth : MonoBehaviour
{
    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    void Awake()
    {
        currentHealth.initialValue = 1;
        //FindObjectOfType<AudioManager>().Play("PlayerHit");    

        // Raise will activate method belonging to it example play a sound when the user takes damage.
        playerHealthSignal.Raise();
    }
}
