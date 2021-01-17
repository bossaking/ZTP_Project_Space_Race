﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayer : MonoBehaviour, IObservable
{
    protected static List<IObserver> Observers { get; set; }
    public float PlayerHealth { get; set; }
    public int PlayerMaxHealth { get; set; }
    public IPlayerState PlayerState { get; set; }
    public GameObject lowSmoke;
    public GameObject fire;
    protected string PlayerNickname { get; set; }
    protected int PlayerDamageForce { get; set; }
    public GameObject BulletGun;
    public GameObject WeakBullet;
    public float AttackDelay;
    public abstract void ReceiveAttackSpeedImproveBonus(float value);
    public abstract void ReceiveAttackSpeedBlowBonus(float value);
    public AbstractDecorator Decorator;


    public abstract void MoveUp();
    public abstract void MoveDown();

    public abstract void Attack();

    public abstract void ReceiveDamage(int damageValue);
    public abstract void Heal(int healValue);
    public abstract void AddObserver(IObserver observer);
    public abstract void RemoveObserver(IObserver observer);
    public abstract void NotifyObservers();

    public AbstractPlayer()
    {
        Observers = new List<IObserver>();
        
    }

    private void Awake()
    {
        WeakBullet = BulletsFactory.GetBulletsFactory().GetBullet("PlayerWeakBullet");
    }
}
