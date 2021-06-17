using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject
{
    public bool didGameLoad;

    void OnEnable()
    {
        didGameLoad = false;
        Debug.Log("Started");
    }
}
