using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstarctEnemy : MonoBehaviour, IEnemyObservable
{


    protected abstract GameObject Bullet { get; set; }
    protected int Health { get; set; }
    protected int DamageForce { get; set; }
    protected Sprite EnemyShipSprite { get; set; }
    protected float AttackDelay { get; set; }


    public AbstarctEnemy()
    {

    }

    protected abstract void Attack();
    public abstract void ReceiveDamage(int damageValue);
    protected void OnEnemyDestroy()
    {
        NotifyObservers();
        Destroy(gameObject);
    }
    protected abstract void Move();

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Border"))
        {
            Destroy(gameObject);
        }
    }

    public abstract void AddObserver(IEnemyObsever observer);
    public abstract void RemoveObserver(IEnemyObsever observer);
    public abstract void NotifyObservers();
}
