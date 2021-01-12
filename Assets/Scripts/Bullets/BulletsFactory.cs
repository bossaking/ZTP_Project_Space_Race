using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFactory : MonoBehaviour
{
    [SerializeField]
    static Dictionary<string, GameObject> bullets;

    private static BulletsFactory _instance;

    public static BulletsFactory GetBulletsFactory()
    {
        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        if (bullets == null)
        {
            bullets = new Dictionary<string, GameObject>
            {
                { "PlayerWeakBullet", Resources.Load<GameObject>("Prefabs/Player Bullets/WeakBullet") },
                { "EnemyWeakBullet", Resources.Load<GameObject>("Prefabs/Enemy Bullets/WeakBullet") },
                { "EnemyNormalBullet", Resources.Load<GameObject>("Prefabs/Enemy Bullets/NormalBullet") },
                { "EnemyStrongBullet", Resources.Load<GameObject>("Prefabs/Enemy Bullets/StrongBullet") }
            };
        }
    }

    public GameObject GetBullet(string bulletKey)
    {
        if (bullets.ContainsKey(bulletKey))
            return bullets[bulletKey];
        else
            return null;
    }
}
