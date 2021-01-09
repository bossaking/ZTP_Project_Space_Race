using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImproveAttackSpeedDecorator : AbstractDecorator
{
    float duration;

    public override void ReceiveAttackSpeedImproveBonus(float value)
    {
        return;
    }

    public override void SetTimer()
    {
        duration = 5f;
        StartCoroutine(Timer());
    }

    public override void Attack()
    {
        Instantiate(abstractPlayer.WeakBullet, abstractPlayer.BulletGun.transform.position, Quaternion.identity);
        abstractPlayer.Invoke(nameof(abstractPlayer.Attack), 0.1f);
    }

    private IEnumerator Timer()
    {
        if (duration > 0)
        {
            duration--;
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine(Timer());
        }
        else
        {
            abstractPlayer.Decorator = gameObject.GetComponent<SimpleAttackDecorator>();
        }
    }

   
}
