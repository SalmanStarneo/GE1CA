using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class NoiseSetting
{
    public float strength = 1;
    public float roughness = 2;
    [Range(1,10)]
    public int numLayers=1;
    public float persistence =.5f;
    public float baseRoughness = 2;
    public float minimumValue;
    public Vector3 center;
}
