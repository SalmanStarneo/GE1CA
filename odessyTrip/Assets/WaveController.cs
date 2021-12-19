using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public float height;
    public float time;


    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash("y",height,"time",time,"looptype","pingpong","easeType",iTween.EaseType.easeInOutSine));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
