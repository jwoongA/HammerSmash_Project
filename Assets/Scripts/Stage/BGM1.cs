using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM1 : MonoBehaviour
{
    public AudioClip bgmClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && bgmClip != null)
        {
            audioSource.clip = bgmClip;
            audioSource.loop = true;
            audioSource.volume = 0.1f;
            audioSource.Play();
        }
    }
}
