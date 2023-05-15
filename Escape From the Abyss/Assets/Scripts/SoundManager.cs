using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    

    public AudioClip[] soundTracks;

    private AudioSource audioSource;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = soundTracks[Random.Range(0, soundTracks.Length)];
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }




}
