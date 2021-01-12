using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardGameState : MonoBehaviour, IGameState
{
    public void Score(MainGameController gameController)
    {
    }

    public void SetGameStrategy(MainGameController gameController)
    {
        Destroy(gameObject.GetComponent<NormalLevel>());
        gameController.SetStrategy(gameObject.AddComponent<HardLevel>());
    }
}
