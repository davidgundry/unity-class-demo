using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public SpawnPoints spawnPoints;
    void Start(){
        Spawn();
    }

    public void Spawn() {
       for (int i=0;i<spawnPoints.points.Count; i++)
        {
            GameObject go = Instantiate(spawnPoints.points[i].prefab, spawnPoints.points[i].position, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = spawnPoints.points[i].velocity;
        }
    }
}