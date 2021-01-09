using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour, IObserver
{
    private GameObject mPlayerPrefab;
    private AbstractPlayer mPlayer;

    public GameObject playerInstantiationPoint;

    public GameObject playerHealthBarIndicator;
    private Image playerHealthBarIndicatorImage;

    private IGameStartegy _gameStrategy;

    void Start()
    {
        gameObject.AddComponent<BulletsFactory>();
        playerHealthBarIndicatorImage = playerHealthBarIndicator.GetComponent<Image>();
        mPlayerPrefab = Resources.Load<GameObject>("Prefabs/Player Ships/Player Ship");
        InstantiatePlayer();
        mPlayer = mPlayerPrefab.GetComponent<AbstractPlayer>();
        mPlayer.AddObserver(this);

        SetStrategy(gameObject.AddComponent<EasyLevel>());
    }

    //PlayerInstantiation
    private void InstantiatePlayer()
    {
        Instantiate(mPlayerPrefab, playerInstantiationPoint.transform.position, Quaternion.identity);
    }

    public void UpdatePlayerInformations(int playerHealth)
    {
        playerHealthBarIndicatorImage.fillAmount = (float)playerHealth / 100;
    }

    public void SetStrategy(IGameStartegy gameStartegy)
    {
        this._gameStrategy = gameStartegy;
        _gameStrategy.SpawnEnemies();
    }
}
