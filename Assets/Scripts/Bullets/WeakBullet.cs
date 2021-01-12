using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBullet : Bullet
{

    private Animator anim;

    protected override void DestroyBullet()
    {
        anim.SetTrigger("Expl");
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();

        Damage = 5;
    }
}
