using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjAudioScript : MonoBehaviour
{
    public AudioSource objLanded;
    public AudioSource objFalling;
    public AudioSource objBouncing;
    
    public UnityEvent objLandedEvent;
    public UnityEvent objFallingEvent;
    public UnityEvent objBouncingEvent;

    public UnityEvent objStopFallingEvent;

    // Start is called before the first frame update
    void Start()
    {
        objLandedEvent ??= new UnityEvent();
        objFallingEvent ??= new UnityEvent();
        objStopFallingEvent ??= new UnityEvent();
        objBouncingEvent ??= new UnityEvent();
        
        objLandedEvent.AddListener(SfxObjLandedPlay);
        objFallingEvent.AddListener(SfxObjFallingPlay);
        objBouncingEvent.AddListener(SfxBouncingPlay);

        objStopFallingEvent.AddListener(SfxObjFallingStop);
    }

    void SfxObjLandedPlay()
    {
        if (!objLanded.isPlaying)
        {
            objLanded.Play();
        }
    }

    void SfxObjFallingPlay()
    {
        if (!objFalling.isPlaying)
        {
            objFalling.Play();
        }
    }

    void SfxObjFallingStop()
    {
        objFalling.Stop();
    }

    void SfxBouncingPlay()
    {
        objBouncing.Play();
    }
}