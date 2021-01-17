using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLevel : MonoBehaviour, IGameStartegy, IEnemyObsever
{
    public EnemyCreator EnemyCreator { get; set; }
    public List<GameObject> spawnPoints { get; set; }
    public float EnemySpawnFrequency { get; set; }

    private GameObject lastSpawnPoint, removedSpawnPoint;

    public List<GameObject> normalBonuses;

    private void Awake()
    {
        EnemyCreator = gameObject.AddComponent<NormalEnemyCreator>();
        spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Spawn Point"));
        normalBonuses = new List<GameObject>();
        normalBonuses.AddRange(Resources.LoadAll<GameObject>("Prefabs/Bonuses/Normal Bonuses/Good Bonuses"));
        normalBonuses.AddRange(Resources.LoadAll<GameObject>("Prefabs/Bonuses/Normal Bonuses/Bad Bonuses"));

        EnemySpawnFrequency = 1.75f;
    }



    public void SpawnEnemies()
    {
        if (removedSpawnPoint != null)
        {
            spawnPoints.Remove(removedSpawnPoint);
        }
        
        int randomPosition = Random.Range(0, spawnPoints.Count);
        lastSpawnPoint = spawnPoints[randomPosition];
        GameObject mNormalEnemyPrefab = Instantiate(EnemyCreator.CreateEnemy(), lastSpawnPoint.transform.position, Quaternion.identity);
        mNormalEnemyPrefab.gameObject.GetComponent<AbstarctEnemy>().AddObserver(this);
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

    public void SpawnBonus(Vector3 position)
    {
        int maxValue = normalBonuses.Count + 2;
        int randomPosition = Random.Range(0, maxValue);

        if(randomPosition < normalBonuses.Count)
        Instantiate(normalBonuses[randomPosition], position, Quaternion.identity);
    }

    public void OnEnemyDestroy(Vector3 position)
    {
        SpawnBonus(position);
    }
}
