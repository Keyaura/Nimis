using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float SpawnTimer;
    [SerializeField]float RespawnTime = 10, RespawnTimeMinimum = 7.5f, RespawnTimeDecrease = 0.25f, RandomDelay;
    public GameObject EnemyPrefab1;
    public GameObject EnemyPrefab2;
    public GameObject EnemyPrefab3;
    public GameObject EnemyPrefab4;
    private Object randomenemy;

    // Update is called once per frame
    void Update()
    {
        SpawnTimer += Time.deltaTime;
        if (SpawnTimer > RespawnTime)
        {
            Spawner();
        }
    }
    public void Spawner()
    {
        RandomDelay = Random.Range(-5f,5f);
        SpawnTimer = SpawnTimer + RandomDelay;
        SpawnTimer = 0;
        print(SpawnTimer);
        Randomenemy();
        if (RespawnTime != RespawnTimeMinimum)
        {
            RespawnTime -= RespawnTimeDecrease;
        }
    }
    public void Randomenemy()
    {
        int random = Random.Range(1,5);
        switch (random)
        {
            case 1:
                Instantiate(EnemyPrefab1, transform.position, transform.rotation);
            break;
            case 2:
                Instantiate(EnemyPrefab2, transform.position, transform.rotation);
            break;
            case 3:
                Instantiate(EnemyPrefab3, transform.position, transform.rotation);
            break;
            case 4:
                Instantiate(EnemyPrefab4, transform.position, transform.rotation);
                break;
        }
    }
}
