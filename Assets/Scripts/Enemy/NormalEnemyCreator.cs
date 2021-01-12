using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyCreator : EnemyCreator
{

    private GameObject mNormalEnemyPrefab;

    private void Awake()
    {
        mNormalEnemyPrefab = Resources.Load<GameObject>("Prefabs/Normal Enemy Ships/Normal Enemy Ship");
    }

    public override GameObject CreateEnemy()
    {
        return mNormalEnemyPrefab;
    }
}
