using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImproveAttackSpeedDecorator : AbstractDecorator
{
    float duration;
    float bonusValue;

    public override void ReceiveAttackSpeedImproveBonus(float value)
    {
        return;
    }

    public override void SetValues(float value)
    {
        bonusValue = value;
        duration = 5f;
        StartCoroutine(Timer());
    }

    public override void Attack()
    {
        Instantiate(abstractPlayer.WeakBullet, abstractPlayer.BulletGun.transform.position, Quaternion.identity);
        abstractPlayer.Invoke(nameof(abstractPlayer.Attack), bonusValue);
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
        abstractPlayer.Decorator = gameObject.GetComponent<BlowAttackSpeedDecorator>();
        abstractPlayer.Decorator.SetValues(value);
        abstractPlayer.CancelInvoke();
        StopAllCoroutines();
        abstractPlayer.Invoke(nameof(abstractPlayer.Attack), 0);
    }
}
