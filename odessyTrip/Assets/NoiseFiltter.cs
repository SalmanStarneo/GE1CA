using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFiltter
{
   NoiseSetting nSetting;
   Noise noise = new Noise();

   public NoiseFiltter(NoiseSetting nSetting)
   {
       this.nSetting = nSetting;
   }

   public float Evaluate(Vector3 point)
   {
        float noiseValue = 0;
        float frequency = nSetting.baseRoughness;
        float amplitude = 1;
        for(int i=0 ; i<nSetting.numLayers;i++)
        {
            float noiseV = noise.Evaluate(point*frequency+nSetting.center);
            noiseValue += (noiseV+1)*0.5f*amplitude;
            frequency  *= nSetting.roughness;
            amplitude *= nSetting.persistence;
        }
        noiseValue=Mathf.Max(0, noiseValue-nSetting.minimumValue);
        return noiseValue*(nSetting.strength);
   }
}
