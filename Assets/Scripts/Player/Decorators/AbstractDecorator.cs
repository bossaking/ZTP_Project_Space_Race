using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDecorator : AbstractPlayer
{
    protected static AbstractPlayer abstractPlayer;

    public void SetPlayer(AbstractPlayer player)
    {
        abstractPlayer = player;
    }

    public virtual void SetTimer() { }

    public override void AddObserver(IObserver observer)
    {
        abstractPlayer.AddObserver(observer);
    }

    public override void Heal(int healValue)
    {
        abstractPlayer.Heal(healValue);
    }

    public override void NotifyObservers()
    {
        abstractPlayer.NotifyObservers();
    }

    public override void ReceiveDamage(int damageValue)
    {
        abstractPlayer.ReceiveDamage(damageValue);
    }

    public override void RemoveObserver(IObserver observer)
    {
        abstractPlayer.RemoveObserver(observer);
    }

    public override void MoveDown()
    {
        abstractPlayer.MoveDown();
    }

    public override void MoveUp()
    {
        abstractPlayer.MoveUp();
    }

}
