using System.Collections.Generic;
using UnityEngine;

public interface IGameStartegy
{
    EnemyCreator EnemyCreator { get; set; }
    List<GameObject> spawnPoints { get; set; }
    float EnemySpawnFrequency { get; set; } //in seconds
    void SpawnEnemies();
    void SpawnBonus(Vector3 position);
}
