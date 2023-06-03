using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
using UnityEngine.Rendering.PostProcessing;

public class TelevisionScare : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject television;
    [SerializeField] private VideoClip myclip;
    [SerializeField] private GameObject postProcess;
    [SerializeField] private GameObject lights;

    private Component[] light;

    private Light tvLight;
    private AudioSource audioClip;


    private VideoPlayer videoPlayer;
    public int frameCount;

    private void Start()
    {
        videoPlayer = television.GetComponent<VideoPlayer>();
        tvLight = television.GetComponentInChildren<Light>();
        audioClip = television.GetComponentInChildren<AudioSource>();

        light = lights.GetComponentsInChildren<Light>();
    }

    public void TelevisionEvent()
    {
        mainCamera.transform.LookAt(television.transform);
        tvLight.color = Color.white;
        tvLight.intensity = 3.0f;
        audioClip.volume = 0.2f;
        Camera.main.fieldOfView= 30;
        player.SetActive(false);
        videoPlayer.clip = myclip;
        videoPlayer.isLooping = false;
        frameCount = (int)videoPlayer.frameCount;

        StartCoroutine(VideoPlaying());
       
    }

    private IEnumerator VideoPlaying()
    {
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        player.SetActive(true);
        tvLight.intensity = 0;
            
    }

    public void EnviromentChange()
    {
        
        tvLight.intensity = 5; tvLight.color = Color.red;

        foreach (Light light in light)
        {
            light.color = Color.red;
        }
    }

}
