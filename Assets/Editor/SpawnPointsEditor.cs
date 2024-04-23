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
        EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
        if(GUILayout.Button("Add"))
        {
           spawnPoints.Add();
        }
        if(GUILayout.Button("Spawn"))
        {
           spawnPoints.Spawn();
        }
    }
}

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Spawner spawner = (Spawner) target;
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("When 'Spawn' is clicked, the objects are instantiated", MessageType.Info);
        if(GUILayout.Button("Spawn"))
        {
           spawner.Spawn();
        }
    }
}

