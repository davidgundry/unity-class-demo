using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/SpawnPoints"), ExecuteInEditMode]
public class SpawnPoints : ScriptableObject
{
    public List<SpawnPoint> points;

    public void Add() {
        points.Add(new SpawnPoint());
    }

    [MenuItem("Tools/Spawn Points")]
    private static void NewMenuOption()
    {
        Debug.Log("Run");
    }

    public void Spawn() {
       for (int i=0;i<points.Count; i++)
        {
            GameObject go = Instantiate(points[i].prefab, points[i].position, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = points[i].velocity;
            go.GetComponent<Rigidbody>().mass = 1000;
        }
    }
}

[Serializable]
public class SpawnPoint
{
    public Vector3 position;
    public GameObject prefab;
    public Vector3 velocity;
}
