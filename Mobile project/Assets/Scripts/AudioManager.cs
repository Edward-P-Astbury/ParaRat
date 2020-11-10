using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    // Singleton pattern to have a single instance of the class
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // If we already have an instance we destory the duplicate
            Destroy(gameObject);
            return; // Ensures no more code is called before we destory the gameObject
        }

        // Searches through the sounds array and adds the AudioSource component to the gameObject
        foreach (Sound s in sounds)
        {
            // Assign values to variables so that we can play them through Play method
            s.Source = gameObject.AddComponent<AudioSource>();

            // Copy the settings over for each audio clip
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
            s.Source.spatialBlend = s.SpatialBlend;
        }
    }

    public void Play(string name)
    {
        // Lambda expression
        // Searching through where sound variable name is equal to passed in parameter
        Sound s = Array.Find(sounds, sound => sound.Name == name);

        // If null we just exit the method
        if (s == null)
        {
            Debug.LogWarning("Sound file: " + name + " wasn't found");
            return;
        }

        s.Source.Play();
    }
}
