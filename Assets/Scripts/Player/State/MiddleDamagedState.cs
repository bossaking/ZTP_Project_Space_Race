using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleDamagedState : MonoBehaviour, IPlayerState
{

    public void Heal(AbstractPlayer player, int healValue)
    {

        player.PlayerHealth += healValue * 1.1f;

        if(player.PlayerHealth / (player.PlayerMaxHealth / 100) > 80)
        {
            SetVisibleDamage(player);
            player.PlayerState = gameObject.AddComponent<NotDamagedState>();
            Destroy(this);
        }
    }

    public void ReceiveDamage(AbstractPlayer player, int damageValue)
    {

        player.PlayerHealth -= damageValue * 0.9f;

        if (player.PlayerHealth / (player.PlayerMaxHealth / 100) <= 45)
        {
            player.PlayerState = gameObject.AddComponent<HighDamagedState>();
            player.PlayerState.SetVisibleDamage(player);
            Destroy(this);
        }
    }

    public void SetVisibleDamage(AbstractPlayer player)
    {
        player.lowSmoke.SetActive(!player.lowSmoke.activeSelf);
    }
}
