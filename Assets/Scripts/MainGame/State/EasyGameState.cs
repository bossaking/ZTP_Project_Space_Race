using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGameState : MonoBehaviour, IGameState
{
    public void Score(MainGameController gameController)
    {
        if(gameController.score >= 1000)
        {
            gameController._gameState = gameObject.AddComponent<NormalGameState>();
            gameController._gameState.SetGameStrategy(gameController);
            Destroy(this);
        }
    }

    public void SetGameStrategy(MainGameController gameController)
    {
        gameController.SetStrategy(gameObject.AddComponent<EasyLevel>());
    }
}
