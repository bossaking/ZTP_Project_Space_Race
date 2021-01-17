﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighDamagedState : MonoBehaviour, IPlayerState
{
    public void Heal(AbstractPlayer player, int healValue)
    {
        player.PlayerHealth += healValue * 1.2f;

        if (player.PlayerHealth / (player.PlayerMaxHealth / 100) > 45)
        {
            SetVisibleDamage(player);
            player.PlayerState = gameObject.AddComponent<MiddleDamagedState>();
            Destroy(this);
        }
    }

    public void ReceiveDamage(AbstractPlayer player, int damageValue)
    {
        player.PlayerHealth -= damageValue * 0.8f;

        if (player.PlayerHealth <= 0)
        {
            player.fire.SetActive(false);
            player.lowSmoke.SetActive(false);
        }
    }

    public void SetVisibleDamage(AbstractPlayer player)
    {
        player.fire.SetActive(!player.fire.activeSelf);
    }
}
