using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour, IObserver
{
    public GameObject PausePanel;
    public GameObject LosePanel;
    public Text ScoreIndicator;
    public int score = 0;
    private readonly float scoreFrequency = 0.1f;

    private GameObject mPlayerPrefab;
    private AbstractPlayer mPlayer;

    public GameObject playerInstantiationPoint;

    public GameObject playerHealthBarIndicator;
    private Image playerHealthBarIndicatorImage;

    private IGameStartegy _gameStrategy;

    LevelStyle levelStyle;
    public IGameState _gameState;

    void Start()
    {

        gameObject.AddComponent<BulletsFactory>();
        playerHealthBarIndicatorImage = playerHealthBarIndicator.GetComponent<Image>();
        mPlayerPrefab = Resources.Load<GameObject>("Prefabs/Player Ships/Player Ship");
        InstantiatePlayer();
        mPlayer = mPlayerPrefab.GetComponent<AbstractPlayer>();
        mPlayer.AddObserver(this);

        levelStyle = GameObject.FindGameObjectWithTag("Level Style").GetComponent<LevelStyle>();
        levelStyle.SetLevelStyle();

        _gameState = gameObject.AddComponent<EasyGameState>();
        _gameState.SetGameStrategy(this);

        InvokeRepeating(nameof(Score), scoreFrequency, scoreFrequency);

        Time.timeScale = 1;
    }

    //PlayerInstantiation
    private void InstantiatePlayer()
    {
        Instantiate(mPlayerPrefab, playerInstantiationPoint.transform.position, Quaternion.identity);
    }

    public void UpdatePlayerInformations(int playerHealth)
    {
        Debug.Log(playerHealth);
        playerHealthBarIndicatorImage.fillAmount = (float)playerHealth / 100;
    }

    public void Lose()
    {
        Time.timeScale = 0;
        LosePanel.SetActive(true);
    }

    public void SetStrategy(IGameStartegy gameStartegy)
    {
        this._gameStrategy = gameStartegy;
        _gameStrategy.SpawnEnemies();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                PausePanel.SetActive(true);
            }
            else
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void Score()
    {
        score++;
        ScoreIndicator.text = score.ToString();
        _gameState.Score(this);
    }
}
