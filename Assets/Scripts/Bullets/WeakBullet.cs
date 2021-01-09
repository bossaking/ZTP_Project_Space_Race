using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBullet : Bullet
{
    private void Awake()
    {
        Damage = 5;
    }
}
