using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemyCount = 0;
    private float GENERATE_DISTANCE = 40f;
    private int MAX_ENEMIES = 10;
    private float BUS_WEIGHT = 18144f;
    private int DEFAULT_POSITION = 0;
    private int PIVOT_ROTATION = 180;
    private float GENERATE_HOLT = 2f;
    private int INCREASE_COUNT = 1;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(enemyCount < MAX_ENEMIES)
        {
            yield return new WaitForSeconds(GENERATE_HOLT);
            Quaternion enemyRotation = Quaternion.Euler(DEFAULT_POSITION, PIVOT_ROTATION, DEFAULT_POSITION);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, DEFAULT_POSITION, transform.position.z + GENERATE_DISTANCE), enemyRotation);
            Rigidbody enemyRB = enemy.AddComponent<Rigidbody>();
            enemyRB.mass = BUS_WEIGHT;
            enemy.AddComponent<BusController>();
            enemyCount += INCREASE_COUNT;
        }
    }
}
