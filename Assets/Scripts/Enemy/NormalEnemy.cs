using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : AbstarctEnemy
{

    public GameObject bulletGun;
    public float attackDelay;//in seconds

    private Animator anim;

    protected override GameObject Bullet { get; set; }

    public static List<IEnemyObsever> observers;

    private void OnEnable()
    {
        observers = new List<IEnemyObsever>();
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Health = 15;
        attackDelay = 1f;
        Bullet = BulletsFactory.GetBulletsFactory().GetBullet("EnemyNormalBullet");
        InvokeRepeating(nameof(Attack), 0.5f, attackDelay);
    }

    public override void ReceiveDamage(int damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            anim.SetTrigger("Death");
            CancelInvoke();
            Invoke(nameof(OnEnemyDestroy), 0.9f);
        }
    }

    protected override void Attack()
    {
        Instantiate(Bullet, bulletGun.transform.position, Quaternion.identity);
    }

    protected override void Move()
    {
        this.transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
    }

    public override void AddObserver(IEnemyObsever observer)
    {
        observers.Add(observer);
    }

    public override void RemoveObserver(IEnemyObsever observer)
    {
        observers.Remove(observer);
    }

    public override void NotifyObservers()
    {
        foreach (IEnemyObsever enemyObsever in observers)
        {
            enemyObsever.OnEnemyDestroy(gameObject.transform.position);
        }
    }
}
