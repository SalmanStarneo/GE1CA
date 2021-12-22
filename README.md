# GE1CA

# Project Title: Dimensional Travel.

Name:Salman Alsamiri

Student Number: D18124618

Class Group:TU856/4

# Description of the project:

The Project will follow the previous idea, but with little changes, like a SeaWater Plane will be included along with perlin noise generated Terrain
that will mimic rocks under the water. The Idea will remain about a vehicle that will be moving endlessly but rather than a tunnel it will be flying over the Ocean in an
illusion that it is traveling across to different worlds far over the horizen. The ship is made using Blender and insearted as an GameObject that will act as a child to the
camera where the camera will display a 3rd person view of the vehicle flying.
----------------
# Instructions for use:

1. The Game will run within unity and the Audio can be changed from the Audio manager to control the Audio Clips, the Moon/Planet Setting can be changed and played around with changing the density, roughness, noise value and even the Radius of the planet, and to set it back to default setting clicking on the button in the GameObject *Moon* script component *planet*'s button. 
2. The user can pause the game by clicking either "Alt" buttons on the keyboard and to unpause it just click it again or click on the screen button "Resume".
----------------
# How it works
###by running the unity project and it will start by displaying an illusion of a flight through a starry sky across the sea to journey to different new worlds.

### Where the water plane will obtain the by running and changing with the Shedder and the cloth component it is attached to.

### The sky box has been changed Twice:
1. First as a component that had a night gradiant;
2. The second time it changed to shedder that changes and manipulte the skybox using multiple nodes like Vovio effect and Normalizing to give the skybox shimmering stars effect from different angles;
----------------
# List of classes/assets in the project:
| Class/asset | Source |
|-----------|-----------|
| AudioManager.cs | Self Written|
| ColorSetting.cs | Self Written/Modified from [Sebastian Lague]() |
| ShapeSetting.cs | Self Written/Modified from [Sebastian Lague]() |
| Settings/Color.cs | Self Written/Modified from [Sebastian Lague]() |
| Settings/Shape.cs | Self Written/Modified from [Sebastian Lague]() |
| Renderer.cs |from [Unity]|
|ScreenPause.cs|Self Written/Modified from [Brackeyes]() |
|PauseControl.cs|Self Written|
| Sounds.cs | Self Written|
| TerrainFace.cs | Self Written/Modified from [Sebastian Lague]() |
| TerrainGenerator.cs | Self Written/Modified from [Brackeyes]() |
| NoiseSetting.cs | Self Written/Modified from [Sebastian Lague]() |
| NoiseFiltter.cs | Self Written/Modified from [Sebastian Lague]() |
| Noise.cs | From [Stefan Gustavson, Linkping University, Sweden] (stegu at itn dot liu dot se)
From [Karsten Schmidt](slight optimizations & restructuring) |
| CustomSK.mat | Self Written|
| Rocks.mat | Self Written|
| Standard.mat | Self Written|
| Stars.mat | Self Written|
| Water.mat | Self Written|
| Flame.vfx | Self Written|
|FireWorks.vfx|Self Written|
|Colour Palette(for the spaceShip)|from [https://lospec.com/palette-list]|
----------------
# References
- Brackeyes 
- Sebastian Lague
--------------------
# What I am most proud of in the assignment
- The *skybox*.
- The *water plane*.
- Spent hours debugging the Render Pipeline and 
fixing the graphic settings for unity, so that the sheders works properly.

- Fixing the planet display and metrial, as after getting the universal pipeline working for 
the other objects it took a while for to have it retain its matrial.

- Making complex low poly model in blender.
- transfering blender model to unity and setting colours to the gameObject models.

- Creating the Pause Menu and the Control script for it.

-------------------------
# Proposal submitted earlier:
My Idea for the Game Engine 1 CA is to create a scene where a vehicle that will be going through an endless(Looping) tunnle with colourful objects floating around,   
as it will be similar to the scenes from digimon our war game movie when they go through internet connection tunnels and space oddesy movie hyper speed scene, 
where it will change colour, move and float around with the beat of the music.
---------------------------
This is the display youtube video:

[![OdissyTrip_VideoDisplay_Youtube](https://github.com/SalmanStarneo/GE1CA/blob/main/Screenshot%202021-12-22%20020211.png?raw=true)](https://www.youtube.com/watch?v=r_Bpd2F__3U)
-------------------------
C# Script

```
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


}

```
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

```
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

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;
    Editor editorPlanet;
    Editor editorShape;

    public override void OnInspectorGUI( )
    {
        using(var checkChange = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if(checkChange.changed)
            {
                planet.GeneratePlanet();
            }
        }

        if(GUILayout.Button("Update/Generate a Planet/moon"))
        {
            planet.GeneratePlanet();
        }
        DrawSettingsEditor(planet.shapeSetting,planet.OnShapeSettingsUpdated, ref planet.shapeSettingFoldout, ref editorShape);
        DrawSettingsEditor(planet.colorSetting,planet.OnColourSettingsUpdated, ref planet.colorSettingFoldout, ref editorPlanet);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor)
    {
        if(settings!=null)
        {
            foldout=EditorGUILayout.InspectorTitlebar(foldout,settings);

            using(var checkChange = new EditorGUI.ChangeCheckScope())
            {
                if(foldout)
                {
                    CreateCachedEditor(settings,null, ref editor);
                    // Editor editor = CreateEditor(settings);
                    editor.OnInspectorGUI();

                    if(checkChange.changed)
                    {
                        if(onSettingsUpdated!=null)
                        {
                            onSettingsUpdated();
                        }
                    }
                }
            
            }
       }
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}

```

```
```

```
```
This is an image using a relative URL:

![An image](images/p8.png)

This is an image using an absolute URL:

![A different image](https://bryanduggandotorg.files.wordpress.com/2019/02/infinite-forms-00045.png?w=595&h=&zoom=2)

