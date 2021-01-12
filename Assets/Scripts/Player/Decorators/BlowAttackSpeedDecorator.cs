﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowAttackSpeedDecorator : AbstractDecorator
{

    float duration;
    float bonusValue;

    public override void Attack()
    {
        Instantiate(abstractPlayer.WeakBullet, abstractPlayer.BulletGun.transform.position, Quaternion.identity);
        abstractPlayer.Invoke(nameof(abstractPlayer.Attack), abstractPlayer.AttackDelay + bonusValue);
    }

    public override void SetValues(float value)
    {
        bonusValue = value;
        duration = 3f;
        StartCoroutine(Timer());
    }

    public override void ReceiveAttackSpeedImproveBonus(float value)
    {
        return;
    }

    private IEnumerator Timer()
    {
        if (duration > 0)
        {
            duration--;
            yield return new WaitForSeconds(1f);
            StartCoroutine(Timer());
        }
        else
        {
            abstractPlayer.Decorator = gameObject.GetComponent<SimpleAttackDecorator>();
        }
    }

    public override void ReceiveAttackSpeedBlowBonus(float value)
    {
        return;
    }
}