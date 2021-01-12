using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelStyle : MonoBehaviour
{

    private void Awake()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy();
        }
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
