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
