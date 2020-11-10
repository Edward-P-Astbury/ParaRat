using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable] // Marking as serializable so it can appear in the inspector
public class Sound
{
    [SerializeField] private string name;

    [SerializeField] private AudioClip clip;

    // Use Range attribute to add slider in inspector
    [Range(0f, 1f)]
    [SerializeField] private float volume;

    [Range(0.1f, 3f)]
    [SerializeField] private float pitch;

    private AudioSource source;

    [SerializeField] private bool loop;

    // 2D to 3D
    [Range(0.0f, 1.0f)]
    [SerializeField] private float spatialBlend;

    #region Properties

    public AudioSource Source
    {
        get
        {
            return source;
        }
        set
        {
            source = value;
        }
    }

    public AudioClip Clip
    {
        get
        {
            return clip;
        }
        set
        {
            clip = value;
        }
    }

    public float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
        }
    }

    public float Pitch
    {
        get
        {
            return pitch;
        }
        set
        {
            pitch = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public bool Loop
    {
        get
        {
            return loop;
        }
        set
        {
            loop = value;
        }
    }

    public float SpatialBlend
    {
        get
        {
            return spatialBlend;
        }
        set
        {
            spatialBlend = value;
        }
    }

    #endregion
}
