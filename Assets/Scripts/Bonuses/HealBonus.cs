using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBonus : Bonus
{
    public int healValue;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<AbstractPlayer>().Heal(healValue);
            Destroy(gameObject);
        }
        if (tag.Equals("Border"))
        {
            Destroy(gameObject);
        }
    }
}
