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
        float elevation = 0;
        for(int i=0; i<noiseFiltters.Length; i++)
        {
            elevation+=noiseFiltters[i].Evaluate(pointOnUnitSphere);
        }
        return pointOnUnitSphere * shapeSetting.planetRadius*(elevation+1);
    }
}
