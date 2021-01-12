using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDamagedState : MonoBehaviour, IPlayerState
{
    public void Heal(AbstractPlayer player, int healValue)
    {
    }

    public void ReceiveDamage(AbstractPlayer player, int damageValue)
    {
        if(player.PlayerHealth / (player.PlayerMaxHealth / 100) <= 80)
        {
            player.PlayerState = gameObject.AddComponent<MiddleDamagedState>();
            player.PlayerState.SetVisibleDamage(player);
            Destroy(this);
        }
    }

    public void SetVisibleDamage(AbstractPlayer player)
    {
    }
}
