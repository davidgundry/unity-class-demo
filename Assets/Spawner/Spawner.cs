using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public SpawnPoints spawnPoints;
    private List<GameObject> offspring  = new List<GameObject>();

    public void Reset() {
        for (int i=0; i<offspring.Count; i++)
            DestroyImmediate(offspring[i]);
    }

    public void Spawn() {
        for (int i=0;i<spawnPoints.points.Count; i++)
        {
            GameObject go = Instantiate(spawnPoints.points[i].prefab, spawnPoints.points[i].position, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = spawnPoints.points[i].velocity;
            offspring.Add(go);
        }
    }
}