using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Signal", fileName = "Signal")]
public class Signal : ScriptableObject
{
    
    public List<SignalListener> listeners = new List<SignalListener>();
    
    // This loops through all the signals, for each of them it raises a method.
    public void Raise()
    {
        // Start from end of list
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    // This adds to the list
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    // This removes from the list
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
