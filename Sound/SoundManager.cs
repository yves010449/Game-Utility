using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;

/// <summary>
/// Manages the playback of audio sounds in the game.
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            if (s.source.playOnAwake)
            {
                s.source.Play();
            }
        }
    }

    /// <summary>
    /// Plays the sound with the specified name.
    /// </summary>
    /// <param name="name">The name of the sound to be played.</param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        // Reset the volume to its original value
        s.source.volume = s.volume;

        // Play the sound
        s.source.Play();
    }

    /// <summary>
    /// Stops the sound with the specified name.
    /// </summary>
    /// <param name="name">The name of the sound to be stopped.</param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        try
        {
            s.source.Stop();
        }
        catch
        {
            // Handle exception if necessary
        }
    }

    /// <summary>
    /// Fades out the sound with the specified name over a specified duration.
    /// </summary>
    /// <param name="name">The name of the sound to be faded out.</param>
    /// <param name="fadeDuration">The duration of the fade-out effect.</param>
    public void FadeOut(string name, float fadeDuration)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        StartCoroutine(FadeOutCoroutine(s, fadeDuration));
    }

    private IEnumerator FadeOutCoroutine(Sound sound, float fadeDuration)
    {
        float startVolume = sound.source.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            sound.source.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        sound.source.volume = 0;
        sound.source.Stop();
    }

    /// <summary>
    /// Fades in the sound with the specified name over a specified duration.
    /// </summary>
    /// <param name="name">The name of the sound to be faded in.</param>
    /// <param name="fadeDuration">The duration of the fade-in effect.</param>
    public void FadeIn(string name, float fadeDuration)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        StartCoroutine(FadeInCoroutine(s, fadeDuration));
    }

    private IEnumerator FadeInCoroutine(Sound sound, float fadeDuration)
    {
        float startVolume = 0; // Start with zero volume and increase gradually

        // Ensure the audio source is playing
        sound.source.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            sound.source.volume = Mathf.Lerp(startVolume, sound.volume, t / fadeDuration);
            yield return null;
        }

        sound.source.volume = sound.volume; // Ensure the volume is set to the target volume
    }

    /// <summary>
    /// Pauses all audio sources managed by the SoundManager.
    /// </summary>
    public void Pause()
    {
        foreach (Sound s in sounds)
        {
            s.source.Pause();
        }
    }

    /// <summary>
    /// Unpauses all previously paused audio sources managed by the SoundManager.
    /// </summary>
    public void UnPause()
    {
        foreach (Sound s in sounds)
        {
            s.source.UnPause();
        }
    }
}