using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu()]
public class ShapeSetting : ScriptableObject {
    public float planetRadius = 1;
    // public NoiseSetting noiseSetting;
    public NoiseLayer[] noiseLayers;
    [Serializable]
    public class NoiseLayer
    {
        public bool enabled = true;
        public bool useFirstLayerMask;
        public NoiseSetting noiseSetting;
    }
}
