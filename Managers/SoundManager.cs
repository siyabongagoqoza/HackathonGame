using System;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundManager : MonoBehaviour
{
    public Audio[] sounds;

    void Awake()
    {
        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Debug.Log(sounds.Length);
        if (sounds.Length != 0 || sounds.Length != null) 
        {
            Audio s = Array.Find(sounds, sound => sound.name == name);
            //s.source.Play();
            //s.source.Stop();
        }
    }

    public void Stop(string name)
    {
        if (sounds.Length != 0 || sounds.Length != null)
        {
            Debug.Log("Stop");
            Audio s = Array.Find(sounds, sound => sound.name == name);
            //s.source.Stop();
        }
    }
}