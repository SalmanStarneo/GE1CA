using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSetting shapeSetting;
    NoiseFiltter[] noiseFiltters;

    public ShapeGenerator(ShapeSetting shapeSetting)
    {
        this.shapeSetting = shapeSetting;
        noiseFiltters = new NoiseFiltter[shapeSetting.noiseLayers.Length];
        for(int i=0; i<noiseFiltters.Length; i++)
        {
            noiseFiltters[i] = new NoiseFiltter(shapeSetting.noiseLayers[i].noiseSetting);
        }
    
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue=0;
        float elevation = 0;

        if(noiseFiltters.Length>0)
        {
            firstLayerValue = noiseFiltters[0].Evaluate(pointOnUnitSphere);
            if(shapeSetting.noiseLayers[0].enabled)
            {
                elevation=firstLayerValue;
            }
        }

        for(int i=1; i<noiseFiltters.Length; i++)
        {
            if(shapeSetting.noiseLayers[i].enabled)
            {
                float layerMask =(shapeSetting.noiseLayers[i].useFirstLayerMask)?firstLayerValue:1;
                elevation+=noiseFiltters[i].Evaluate(pointOnUnitSphere)*layerMask;

            }
        }
        return pointOnUnitSphere * shapeSetting.planetRadius*(elevation+1);
    }
}
