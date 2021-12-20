using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSetting shapeSetting;

    public ShapeGenerator(ShapeSetting shapeSetting)
    {
        this.shapeSetting = shapeSetting;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        return pointOnUnitSphere * shapeSetting.planetRadius;
    }
}
