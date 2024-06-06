using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Transform target;
    public float offsetY;
    private ParticleSystem rain;
    private AudioSource rainAudio;

    private void Start()
    {
        rain = GetComponentInChildren<ParticleSystem>();
        rainAudio = GetComponentInChildren<AudioSource>();
    }

    public void StopRain(Component sender, object data)
    {
        rain.Stop(withChildren:true);
        rainAudio.Stop();
    }

    public void StartRain(Component sender, object data)
    {
        rain.Play(withChildren:true);
        rainAudio.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + new Vector3(0, offsetY, 0);
    }
}
