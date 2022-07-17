using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnTime;
    private GameObject newEnemy;
    private SpriteRenderer rend;
    public Transform player;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;

 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, spawnTime);
        
    }

    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0,4);
        Debug.Log(randomSpawnZone);
        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-36f, 19f);
                randomYposition = Random.Range(7f, 33f);
                break;
            case 1:
                randomXposition = Random.Range(21f, 75f);
                randomYposition = Random.Range(7f, 32f);
                break;
            case 2:
                randomXposition = Random.Range(21f, 76f);
                randomYposition = Random.Range(-21f, 5f);
                break;
            case 3:
                randomXposition = Random.Range(-36f, 19f);
                randomYposition = Random.Range(-21f, 6f);
                break;
        }
        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

        AIDestinationSetter targetVar = newEnemy.GetComponent<AIDestinationSetter>();
        targetVar.target = player;

    }
}
