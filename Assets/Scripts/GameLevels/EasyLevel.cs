using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyLevel : MonoBehaviour, IGameStartegy, IEnemyObsever
{
    public EnemyCreator EnemyCreator { get; set; }
    public List<GameObject> spawnPoints { get; set; }
    public List<GameObject> weakBonuses;
    private GameObject lastSpawnPoint, removedSpawnPoint;
    public float EnemySpawnFrequency { get; set; } //in seconds


    private void Awake()
    {
        EnemyCreator = gameObject.AddComponent<EasyEnemyCreator>();
        spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Spawn Point"));
        weakBonuses = new List<GameObject>();
        weakBonuses.AddRange(Resources.LoadAll<GameObject>("Prefabs/Bonuses/Weak Bonuses/Good Bonuses"));
        weakBonuses.AddRange(Resources.LoadAll<GameObject>("Prefabs/Bonuses/Weak Bonuses/Bad Bonuses"));

        EnemySpawnFrequency = 1.5f;
    }

    public void SpawnEnemies()
    {
        if (removedSpawnPoint != null)
        {
            spawnPoints.Remove(removedSpawnPoint);
        }
        
        int randomPosition = Random.Range(0, spawnPoints.Count);
        lastSpawnPoint = spawnPoints[randomPosition];
        GameObject mEasyEnemyPrefab = Instantiate(EnemyCreator.CreateEnemy(), lastSpawnPoint.transform.position, Quaternion.identity);
        mEasyEnemyPrefab.gameObject.GetComponent<AbstarctEnemy>().AddObserver(this);
        if (removedSpawnPoint == null)
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

    public void SpawnBonus(Vector3 position)
    {
        int randomPosition = Random.Range(0, weakBonuses.Count);
        Instantiate(weakBonuses[randomPosition], position, Quaternion.identity);
    }

    public void OnEnemyDestroy(Vector3 position)
    {
        SpawnBonus(position);
    }
}
