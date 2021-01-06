using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractPlayer
{
    //Player health points
    private int playerHealth;
    protected override int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }

    //Player nickname
    private string playerNickname;
    protected override string PlayerNickname { get { return playerNickname; } set { playerNickname = value; } }

    //Player damage force
    private int playerDamageForce;
    protected override int PlayerDamageForce { get { return playerDamageForce; } set { playerDamageForce = value; } }

    //Player attack
    private float attackDelay; //in seconds
    public GameObject bulletGun;
    private GameObject bullet;

    private SpriteRenderer mSpriteRenderer;
    private Collider2D mCollider;
    private Sprite playerShipSprite;

    private float minY, maxY;

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mCollider = GetComponent<Collider2D>();
        bullet = Resources.Load<GameObject>("Prefabs/BlueBullet");

        playerHealth = 100;
        playerNickname = "Player";
        playerDamageForce = 10;

        attackDelay = 1f;

        CalculateMinMaxY();

        InvokeRepeating("Attack", 0, attackDelay);

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

        maxY = fieldHeight - mCollider.bounds.size.y / 2 - 0.5f;
        minY = -fieldHeight + mCollider.bounds.size.y / 2 + 0.5f;
    }

    protected override void MoveUp()
    {
        if(maxY <= this.transform.position.y)
        {
            return;
        }
        this.transform.localPosition += new Vector3(0.0f, 0.1f, 0.0f);
    }

    protected override void MoveDown()
    {
        if(minY >= this.transform.position.y)
        {
            return;
        }
        this.transform.localPosition -= new Vector3(0.0f, 0.1f, 0.0f);
    }

    #endregion

    #region Player Attack

    protected override void Attack()
    {
        Instantiate(bullet, bulletGun.transform.position, Quaternion.identity);
    }

    #endregion
}
