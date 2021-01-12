using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyCreator : EnemyCreator
{

    private GameObject mHardEnemyPrefab;

    private void Awake()
    {
        mHardEnemyPrefab = Resources.Load<GameObject>("Prefabs/Hard Enemy Ships/Hard Enemy Ship");
    }

    public override GameObject CreateEnemy()
    {
        return mHardEnemyPrefab;
    }
}
