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
