using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    
    //Enables Player context
    public void Enable()
    {
        contextClue.SetActive(true);
    }

    //Enables Player disables
    public void Disable()
    {
        contextClue.SetActive(false);
    }
}
