using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManger : MonoBehaviour
{

    ScreenPause screenPause;
    [SerializeField]
    private AudioSource TrackA;
    [SerializeField]
    private AudioSource TrackB;
    [SerializeField]
    private AudioSource TrackC;

    // Start is called before the first frame update
    void Start()
    {
        if(TrackA == null)
        {
            Debug.Log("TrackA has not been inserted");
            enabled=false;
        }
        else
        {
            TrackA.Play();
            
        }
        if(TrackB==null)
        {
            Debug.Log("TrackB has not been inserted");
            enabled=false;
        }
        else
        {
            TrackB.Play();
        }
        if(TrackC!=null)
        {
            TrackC.Play();
        }
      
        TrackA.loop=true;

        TrackB.loop=true;
        
        TrackC.loop=true;

        
    }

    // void Update() 
    // {
    //     if(screenPause.Pause())
    //     {
    //         TrackA.pitch*=.5f;
    //         TrackB.pitch*=.5f;
    //     }   
    // }

}
