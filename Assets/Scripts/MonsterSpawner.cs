using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public bool spawnsEnabled;


    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if(spawnsEnabled) 
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }

}
