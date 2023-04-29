using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicOnStart;
    public AudioSource audioSource;
    public float timeToSwitch;

    private AudioClip switchTo;
    private float volume;

    private void Start()
    {
        Play(musicOnStart, true);
    }


    /// <summary>
    /// Plays the specified music clip, with the option to interrupt any currently playing music.
    /// </summary>
    /// <param name="music">The music clip to play.</param>
    /// <param name="interrupt">Whether or not to interrupt any currently playing music.</param>
    public void Play(AudioClip music, bool interrupt = false)
    {
        if(interrupt)
        {
            volume = 1f;
            audioSource.volume = volume;
            audioSource.clip = music;
            audioSource.Play();
        }
        else
        {
            switchTo = music;
            StartCoroutine(SmoothSwitchMusic());
        }
    }

    /// <summary>
    /// Smoothly switches from the current music to the new music clip.
    /// </summary>
    /// <returns>An IEnumerator object for the coroutine.</returns>
    IEnumerator SmoothSwitchMusic()
    {
        volume = 1f;
        while (volume > 0f)
        {
            volume -= Time.deltaTime / timeToSwitch;
            if(volume < 0f) { volume = 0f; }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }
        Play(switchTo, true);
    }
}
