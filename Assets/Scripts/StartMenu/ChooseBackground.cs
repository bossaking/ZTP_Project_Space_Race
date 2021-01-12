using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseBackground : MonoBehaviour
{
    private int choosenPosition = 0;

    public Image spriteImage;

    public GameObject rightButton, leftButton;

    public List<GameObject> spriteObjects;
    private void Awake()
    {
        spriteObjects = new List<GameObject>();
        spriteObjects.AddRange(Resources.LoadAll<GameObject>("Sprites/Backgrounds"));

        ChooseBackgroundImage(0);

    }

    public void LoadMainGameScene()
    {
        DontDestroyOnLoad(Instantiate(spriteObjects[choosenPosition].gameObject));
        SceneManager.LoadScene(1);
    }

    public void ChooseBackgroundImage(int additionValue)
    {
        choosenPosition += additionValue;

        spriteImage.sprite = spriteObjects[choosenPosition].GetComponent<SpriteRenderer>().sprite;

        if(choosenPosition == 0)
        {
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }

        if(choosenPosition == spriteObjects.Count - 1)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }
    }
}
