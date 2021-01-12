using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowAttackSpeedBonus : Bonus
{
    public float blowAttackSpeedValue;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<AbstractPlayer>().ReceiveAttackSpeedBlowBonus(blowAttackSpeedValue);
            Destroy(gameObject);
        }
        if (tag.Equals("Border"))
        {
            Destroy(gameObject);
        }
    }
}
