using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGameState : MonoBehaviour, IGameState
{
    public void Score(MainGameController gameController)
    {
        if(gameController.score >= 2000)
        {
            gameController._gameState = gameObject.AddComponent<HardGameState>();
            gameController._gameState.SetGameStrategy(gameController);
            Destroy(this);
        }
    }

    public void SetGameStrategy(MainGameController gameController)
    {
        Destroy(gameObject.GetComponent<EasyLevel>());
        gameController.SetStrategy(gameObject.AddComponent<NormalLevel>());
    }
}
