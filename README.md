# GE1CA

# Project Title: Dimensional Travel.

Name:Salman Alsamiri

Student Number: D18124618

Class Group:TU856/4

# Description of the project:

##The Project will follow the previous idea, but with little changes, like a SeaWater Plane will be included along with perlin noise generated Terrain
##that will mimic rocks under the water. The Idea will remain about a vehicle that will be moving endlessly but rather than a tunnel it will be flying over the Ocean in an
##illusion that it is traveling across to different worlds far over the horizen. The ship is made using Blender and insearted as an GameObject that will act as a child to the
##camera where the camera will display a 3rd person view of the vehicle flying.
----------------
# Instructions for use:

1.###The Game will run within unity and the Audio can be changed from the Audio manager to control the Audio Clips, the Moon/Planet Setting can be changed and played around with changing the density, roughness, noise value and even the Radius of the planet, and to set it back to default setting clicking on the button in the GameObject *Moon* script component *planet*'s button. 
2.### The user can pause the game by clicking either "Alt" buttons on the keyboard and to unpause it just click it again or click on the screen button "Resume".
----------------
# How it works
###by running the unity project and it will start by displaying an illusion of a flight through a starry sky across the sea to journey to different new worlds.

### Where the water plane will obtain the by running and changing with the Shedder and the cloth component it is attached to.

### The sky box has been changed Twice:
1. ### First as a component that had a night gradiant;
2. ### The second time it changed to shedder that changes and manipulte the skybox using multiple nodes like Vovio effect and Normalizing to give the skybox shimmering stars effect from different angles;
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

# What I am most proud of in the assignment
- The *skybox*.
- The *water plane*.
- Spent hours debugging the Render Pipeline and 
fixing the graphic settings for unity, so that the sheders works properly.

- Fixing the planet display and metrial, as after getting the universal pipeline working for 
the other objects it took a while for to have it retain its matrial.

- Making complex low poly model in blender.
- transfering blender model to unity and setting colours to the gameObject models.


# Proposal submitted earlier can go here:
My Idea for the Game Engine 1 CA is to create a scene where a vehicle that will be going through an endless(Looping) tunnle with colourful objects floating around,   
as it will be similar to the scenes from digimon our war game movie when they go through internet connection tunnels and space oddesy movie hyper speed scene, 
where it will change colour, move and float around with the beat of the music.


```
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```


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
```
```
This is an image using a relative URL:

![An image](images/p8.png)

This is an image using an absolute URL:

![A different image](https://bryanduggandotorg.files.wordpress.com/2019/02/infinite-forms-00045.png?w=595&h=&zoom=2)

This is a youtube video:

[![YouTube](http://img.youtube.com/vi/J2kHSSFA4NU/0.jpg)](https://www.youtube.com/watch?v=J2kHSSFA4NU)

This is a table:

| Heading 1 | Heading 2 |
|-----------|-----------|
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
