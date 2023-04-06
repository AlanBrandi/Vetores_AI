using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variáveis qual gameobject, rate de spawn, a area e o proximo spawn.
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRate = 2f;
    Collider spawnArea;
    float nextSpawnTime;
    //pega o collider.
    private void Start()
    {
        spawnArea = GetComponent<Collider>();
    }
    private void Update()
    {
        //se o tempo estiver maior que o prox spawn entre
        if (Time.time > nextSpawnTime)
        {
            //coloca o proximo spawntime mais o spawnrate.
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
