using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] float powerspawnRate = 15f;
    [SerializeField] GameObject[] enemyPrefab;

    [SerializeField] GameObject powerUp;

    float xMin;
    float xMax;
    float ySpawn;

    public bool hard;
    // Start is called before the first frame update
    void Start()
    {

        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        InvokeRepeating("SpawnEnemy", 2f, spawnRate);
        InvokeRepeating("SpawnPowerUp", 15f, powerspawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randX = Random.Range(xMin, xMax);
        int ran = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[ran], new Vector3(randX, ySpawn, 0), Quaternion.identity);
        if (hard)
        {
            int rn = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[rn], new Vector3(randX, ySpawn, 0), Quaternion.identity);
        }
    }

    void SpawnPowerUp()
    {

        float randX = Random.Range(xMin, xMax);
        Instantiate(powerUp, new Vector3(randX, ySpawn, 0), Quaternion.identity);
    }
}
