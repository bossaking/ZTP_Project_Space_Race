using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelStyle : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
       
        try
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Destroy(gameObject);
            }
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {

    }

    public void SetLevelStyle()
    {
        SetBackground();
    }

    protected abstract void SetBackground();

    protected void Destroy()
    {
        Destroy(gameObject);
    }

    
}
