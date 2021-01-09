using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedBonus : Bonus
{

    public float additionalAttackSpeed;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<AbstractPlayer>().ReceiveAttackSpeedImproveBonus(additionalAttackSpeed);
            Destroy(gameObject);
        }
        if (tag.Equals("Border"))
        {
            Destroy(gameObject);
        }
    }
}
