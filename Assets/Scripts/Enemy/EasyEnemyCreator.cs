using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemyCreator : EnemyCreator
{

    private GameObject mEasyEnemyPrefab;

    private void Awake()
    {
        mEasyEnemyPrefab = Resources.Load<GameObject>("Prefabs/Easy Enemy Ships/Easy Enemy Ship");
    }

    public override GameObject CreateEnemy()
    {
        return mEasyEnemyPrefab;
    }
}
