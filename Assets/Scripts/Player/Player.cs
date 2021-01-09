using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractPlayer
{
    private SpriteRenderer mSpriteRenderer;
    private Collider2D mCollider;
    private Sprite playerShipSprite;

    //Player movement
    [Header("Player Movement Settings")]
    private float minY, maxY;
    public float playerMovementSpeed = 0.1f; //in points

    

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mCollider = GetComponent<Collider2D>();
        gameObject.AddComponent<BulletsFactory>();
        Decorator = gameObject.GetComponent<SimpleAttackDecorator>();
        Decorator.SetPlayer(this);

        AttackDelay = 1f;
        PlayerHealth = 100;
        PlayerMaxHealth = 101;
        PlayerNickname = "Player";
        PlayerDamageForce = 10;

        CalculateMinMaxY();

        Attack();

    }



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
    }

    #region Player movement

    private void CalculateMinMaxY()
    {
        float fieldHeight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;

        maxY = fieldHeight - mCollider.bounds.size.y / 2 - 1.5f;
        minY = -fieldHeight + mCollider.bounds.size.y / 2 + 0.5f;
    }

    public override void MoveUp()
    {
        if (maxY <= this.transform.position.y)
        {
            return;
        }
        this.transform.localPosition += new Vector3(0.0f, playerMovementSpeed, 0.0f);
    }

    public override void MoveDown()
    {
        if (minY >= this.transform.position.y)
        {
            return;
        }
        this.transform.localPosition -= new Vector3(0.0f, playerMovementSpeed, 0.0f);
    }

    #endregion

    #region Player Attack

    public override void Attack()
    {
        Decorator.Attack();
    }

    public override void ReceiveAttackSpeedImproveBonus(float value)
    {
        Decorator.ReceiveAttackSpeedImproveBonus(value);

    }

    #endregion

    #region Player Damage

    public override void ReceiveDamage(int damageValue)
    {
        PlayerHealth -= damageValue;
        NotifyObservers();
    }

    #endregion

    public override void Heal(int healValue)
    {
        PlayerHealth += healValue;
        PlayerHealth %= PlayerMaxHealth;
        NotifyObservers();
    }

    #region Observers

    public override void AddObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public override void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public override void NotifyObservers()
    {
        foreach (IObserver observer in Observers)
        {
            observer.UpdatePlayerInformations(PlayerHealth);
        }
    }

    #endregion
}
