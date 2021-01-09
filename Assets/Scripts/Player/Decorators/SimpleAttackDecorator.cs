using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttackDecorator : AbstractDecorator
{
    public override void Attack()
    {
        Instantiate(abstractPlayer.WeakBullet, abstractPlayer.BulletGun.transform.position, Quaternion.identity);
        abstractPlayer.Invoke(nameof(abstractPlayer.Attack), abstractPlayer.AttackDelay);
    }

    public override void ReceiveAttackSpeedImproveBonus(float value)
    {
        abstractPlayer.Decorator = gameObject.GetComponent<ImproveAttackSpeedDecorator>();
        abstractPlayer.Decorator.SetTimer();
    }
}
