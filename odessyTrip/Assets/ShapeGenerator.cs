using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSetting shapeSetting;
    NoiseFiltter noiseFiltter;

    public ShapeGenerator(ShapeSetting shapeSetting)
    {
        this.shapeSetting = shapeSetting;
        noiseFiltter = new NoiseFiltter(shapeSetting.noiseSetting);
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = noiseFiltter.Evaluate(pointOnUnitSphere);
        return pointOnUnitSphere * shapeSetting.planetRadius*(elevation+1);
    }
}
