using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Main))]
public class MainEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Main mapGen = (Main)target;
        

        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}
