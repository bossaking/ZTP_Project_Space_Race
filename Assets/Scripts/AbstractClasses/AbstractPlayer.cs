using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayer : MonoBehaviour
{

    protected abstract int PlayerHealth { get; set; }
    protected abstract string PlayerNickname { get; set; }
    protected abstract int PlayerDamageForce { get; set; }

    protected abstract void MoveUp();
    protected abstract void MoveDown();

    protected abstract void Attack();

}
