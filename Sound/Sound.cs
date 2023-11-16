using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Represents a sound with customizable properties such as volume, pitch, loop, etc.
/// </summary>
[System.Serializable]
public class Sound {
    public string name;

    public AudioClip clip;

    [Range(0, 1f)]
    public float volume = 1;
    [Range(0.1f, 3f)]
    public float pitch = 1;
    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
