using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardLevel : MonoBehaviour, IGameStartegy, IEnemyObsever
{
    public EnemyCreator EnemyCreator { get;set; }
    public List<GameObject> spawnPoints { get; set; }
    public float EnemySpawnFrequency { get; set; }

    private GameObject lastSpawnPoint, removedSpawnPoint;

    public List<GameObject> strongBonuses;

    private void Awake()
    {
        EnemyCreator = gameObject.AddComponent<HardEnemyCreator>();
        spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Spawn Point"));
        strongBonuses = new List<GameObject>();
        strongBonuses.AddRange(Resources.LoadAll<GameObject>("Prefabs/Bonuses/Strong Bonuses/Good Bonuses"));
        strongBonuses.AddRange(Resources.LoadAll<GameObject>("Prefabs/Bonuses/Strong Bonuses/Bad Bonuses"));

        EnemySpawnFrequency = 2f;
    }

    public void OnEnemyDestroy(Vector3 position)
    {
        SpawnBonus(position);
    }

    public void SpawnBonus(Vector3 position)
    {
        int maxValue = strongBonuses.Count + 4;
        int randomPosition = Random.Range(0, maxValue);

        if (randomPosition < strongBonuses.Count)
            Instantiate(strongBonuses[randomPosition], position, Quaternion.identity);
    }

    public void SpawnEnemies()
    {
        if (removedSpawnPoint != null)
        {
            spawnPoints.Remove(removedSpawnPoint);
        }

        int randomPosition = Random.Range(0, spawnPoints.Count);
        lastSpawnPoint = spawnPoints[randomPosition];
        GameObject mHardEnemyPrefab = Instantiate(EnemyCreator.CreateEnemy(), lastSpawnPoint.transform.position, Quaternion.identity);
        mHardEnemyPrefab.gameObject.GetComponent<AbstarctEnemy>().AddObserver(this);
        if (removedSpawnPoint == null)
        {
            removedSpawnPoint = lastSpawnPoint;
        }
        else
        {
            spawnPoints.Add(removedSpawnPoint);
            removedSpawnPoint = lastSpawnPoint;
        }
        Invoke(nameof(SpawnEnemies), EnemySpawnFrequency);
    }
}
