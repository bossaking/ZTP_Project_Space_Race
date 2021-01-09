using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstarctEnemy : MonoBehaviour, IEnemyObservable
{

    protected static List<IEnemyObsever> observers;

    protected static GameObject Bullet { get; set; }
    protected int Health { get; set; }
    protected int DamageForce { get; set; }
    protected Sprite EnemyShipSprite { get; set; }
    protected float AttackDelay { get; set; }


    public AbstarctEnemy()
    {
        if (observers == null)
            observers = new List<IEnemyObsever>();
    }

    protected abstract void Attack();
    public abstract void ReceiveDamage(int damageValue);
    protected void OnEnemyDestroy()
    {
        NotifyObservers();
        Destroy(gameObject);
    }
    protected abstract void Move();

    private void Awake()
    {
    }

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

    public void AddObserver(IEnemyObsever observer)
    {
        if (observers.Count == 0)
            observers.Add(observer);
    }

    public void RemoveObserver(IEnemyObsever observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IEnemyObsever enemyObsever in observers)
        {
            enemyObsever.OnEnemyDestroy(gameObject.transform.position);
        }
    }
}
