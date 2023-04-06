using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRate = 2f;
    Collider spawnArea;
    float nextSpawnTime;

    private void Start()
    {
        spawnArea = GetComponent<Collider>();
    }
    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;

            // Gera um ponto aleatório dentro do collider
            Vector3 randomPoint = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

            // Faz o spawn do inimigo na posição aleatória
            Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
        }
    }
}
