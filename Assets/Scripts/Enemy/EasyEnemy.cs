using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : AbstarctEnemy
{

    public GameObject bulletGun;

    public int attackDelay;//in seconds

    private void Start()
    {
        Health = 10;
        Bullet = BulletsFactory.GetBulletsFactory().GetBullet("EnemyWeakBullet");
        InvokeRepeating(nameof(Attack), 0.5f, attackDelay);
    }

    protected override void Attack()
    {
        Instantiate(Bullet, bulletGun.transform.position, Quaternion.identity);
    }

    protected override void Move()
    {
        this.transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
    }

    public override void ReceiveDamage(int damageValue)
    {
        Health -= damageValue;
        if(Health <= 0)
        {
            OnEnemyDestroy();
        }
    }
}
