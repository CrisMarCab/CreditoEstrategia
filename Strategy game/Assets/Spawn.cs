using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Spawn : NetworkBehaviour
{

    public GameObject enemigo;
    int objectsToSpawn;

    public GameObject[] posicionesSpawn;

    public float SpawnInterval = 15;
    public float MaxObjectsSpawned = 8;
    public float MinObjectsSpawned = 3;


    private float _NextSpawn;



    void Start()
    {

        _NextSpawn = Time.time + SpawnInterval;

         objectsToSpawn = (int)Random.Range(MinObjectsSpawned, MaxObjectsSpawned);
    }


    void Update()
    {
        if (Time.time >= _NextSpawn && objectsToSpawn < MaxObjectsSpawned)
        {
            objectsToSpawn = objectsToSpawn + 1;

            Instantiate(enemigo,posicionesSpawn[Random.Range(0,5)].transform.position, Quaternion.identity);

            _NextSpawn = Time.time + SpawnInterval;
        }
    }
}