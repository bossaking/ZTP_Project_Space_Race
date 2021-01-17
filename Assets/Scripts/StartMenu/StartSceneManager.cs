using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{

    public GameObject StartMenuPanel;
    public GameObject ChooseBackgroundPanel;
    public GameObject SettingsPanel;

    public void StartGamePressed()
    {
        StartMenuPanel.SetActive(false);
        ChooseBackgroundPanel.SetActive(true);
    }

    public void SettingsPressed()
    {
        StartMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void BackToStartMenu(GameObject panel)
    {
        panel.SetActive(false);
        StartMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
