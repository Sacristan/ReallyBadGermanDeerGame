using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSpawner : MonoBehaviour {

    GameObject[] spawnPoints;

    [SerializeField] private DeerAI deerPrefab;

    [SerializeField] private uint minSpawnTime = 2;
    [SerializeField] private uint maxSpawnTime = 5;


    void Awake(){
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

    void Start(){
        StartCoroutine(SpawnDeerRoutine());
    }

    IEnumerator SpawnDeerRoutine(){
        while(true){
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnDeer();
        }
    }

    private void SpawnDeer(){

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject spawnPoint = spawnPoints[spawnPointIndex];

        Instantiate(deerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }


}
