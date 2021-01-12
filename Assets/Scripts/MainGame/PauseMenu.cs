﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
