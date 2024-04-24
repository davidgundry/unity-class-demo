using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SpawnPoints))]
public class SpawnPointsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SpawnPoints spawnPoints = (SpawnPoints) target;
        DrawDefaultInspector();
        if(GUILayout.Button("Add"))
           spawnPoints.Add();
    }
}

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Spawner spawner = (Spawner) target;
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("When 'Spawn' is clicked, the objects will be instantiated", MessageType.Info);
        if(GUILayout.Button("Spawn"))
           spawner.Spawn();
        if(GUILayout.Button("Reset"))
           spawner.Reset();
    }
}

