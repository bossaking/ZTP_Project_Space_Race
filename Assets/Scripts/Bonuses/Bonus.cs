using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public BonusTypes BonusType;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
