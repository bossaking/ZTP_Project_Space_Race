using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    public BulletDirectionState bulletDirection;
    protected BulletDirectionState BulletDirectionState { get { return bulletDirection; } set { bulletDirection = value; } }

    protected int Damage { get; set; }


    private void FixedUpdate()
    {
        switch (BulletDirectionState)
        {
            case BulletDirectionState.Player:
                this.transform.position += new Vector3(0.3f, 0.0f, 0.0f);
                break;
            case BulletDirectionState.SimpleEnemy:
                this.transform.position -= new Vector3(0.3f, 0.0f, 0.0f);
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Player") && BulletDirectionState != BulletDirectionState.Player)
        {
            collision.gameObject.GetComponent<AbstractPlayer>().ReceiveDamage(Damage);
            Destroy(gameObject);
        }
        if (tag.Equals("Enemy") && BulletDirectionState != BulletDirectionState.SimpleEnemy)
        {
            collision.gameObject.GetComponent<AbstarctEnemy>().ReceiveDamage(Damage);
            Destroy(gameObject);
        }
        if (tag.Equals("Border"))
        {
            Destroy(gameObject);
        }
    }
}
