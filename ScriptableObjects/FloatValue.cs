using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Serialization is the loading and unload data from memory.
    It is similar to start() method however, it loads everything for the entire game instaead of a particular scene.
*/

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    // Unload everything from the game.
    public void OnAfterDeserialize()
    {
        initialValue = RuntimeValue;
    }

    // Loads everyting in the game.    
    public void OnBeforeSerialize()
    {
        
    }
}
