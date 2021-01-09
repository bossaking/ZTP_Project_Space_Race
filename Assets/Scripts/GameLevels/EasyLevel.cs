using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyLevel : MonoBehaviour, IGameStartegy, IEnemyObsever
{
    public EnemyCreator EnemyCreator { get; set; }
    public List<GameObject> spawnPoints { get; set; }
    public List<GameObject> weakGoodBonuses;
    private GameObject lastSpawnPoint, removedSpawnPoint;
    public float EnemySpawnFrequency { get; set; } //in seconds

    private void Awake()
    {
        EnemyCreator = gameObject.AddComponent<EasyEnemyCreator>();
        spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Easy Enemy Spawn Point"));
        weakGoodBonuses = new List<GameObject>();
        weakGoodBonuses.AddRange(Resources.LoadAll<GameObject>("Prefabs/Bonuses/Weak Bonuses/Good Bonuses"));

        EnemySpawnFrequency = 1.5f;
    }

    public void SpawnEnemies()
    {
        if (removedSpawnPoint != null)
        {
            spawnPoints.Remove(removedSpawnPoint);
        }

        GameObject mEasyEnemyPrefab = EnemyCreator.CreateEnemy();
        mEasyEnemyPrefab.gameObject.GetComponent<AbstarctEnemy>().AddObserver(this);
        int randomPosition = Random.Range(0, spawnPoints.Count);
        lastSpawnPoint = spawnPoints[randomPosition];
        Instantiate(mEasyEnemyPrefab, lastSpawnPoint.transform.position, Quaternion.identity);
        if(removedSpawnPoint == null)
        {
            removedSpawnPoint = lastSpawnPoint;
        }
        else
        {
            spawnPoints.Add(removedSpawnPoint);
            removedSpawnPoint = lastSpawnPoint;
        }
        removedSpawnPoint = lastSpawnPoint;
        Invoke(nameof(SpawnEnemies), EnemySpawnFrequency);
    }

    private void SpawnBonus(Vector3 position)
    {
        int randomPosition = Random.Range(0, weakGoodBonuses.Count);
        Instantiate(weakGoodBonuses[randomPosition], position, Quaternion.identity);
    }

    public void OnEnemyDestroy(Vector3 position)
    {
        SpawnBonus(position);
    }
}
