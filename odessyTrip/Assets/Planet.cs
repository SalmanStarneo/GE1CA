using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    [Range(2,256)]
    public int resolution = 100;

    public bool updatesAutomation=true;

    public ShapeSetting shapeSetting;
    public ColorSetting colorSetting;

    ShapeGenerator shapeGenerator;

    [HideInInspector]
    public bool shapeSettingFoldout;
     [HideInInspector]
    public bool colorSettingFoldout;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;
     
	// private void OnValidate()
	// {
    //     GeneratePlanet();
	// }

	void Initialize()
    {
        shapeGenerator = new ShapeGenerator(shapeSetting);

        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new TerrainFace[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new TerrainFace(shapeGenerator,meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

     public void GeneratePlanet()
    {
        Initialize();
        GenerateMesh();
        GenerateColour();
    }

    public void OnShapeSettingsUpdated()
    {
        if(updatesAutomation)
        {
            Initialize();
            GenerateMesh();
        }

    }

    public void OnColourSettingsUpdated()
    {
        if(updatesAutomation)
        {
            Initialize();
            GenerateColour();
        }
    }

    void GenerateMesh()
    {
        foreach (TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    void GenerateColour()
    {
        foreach (MeshFilter mFilter in meshFilters)
        {
            mFilter.GetComponent<MeshRenderer>().sharedMaterial.color=colorSetting.planetColor;
        }
    }
}