using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScare : MonoBehaviour
{
    [SerializeField] private GameObject ambienceMusic;
    [SerializeField] private GameObject audioSource;
    [SerializeField] private AudioClip ambientClip;
    [SerializeField] private Light flashLight;
    private AudioSource audioClip;

    public void SoundEffect()
    {
        audioSource.GetComponent<AudioSource>().clip = ambientClip;
    }
}
