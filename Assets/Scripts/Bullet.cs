using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    private void Start()
    {
        damage = 10;
    }

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
