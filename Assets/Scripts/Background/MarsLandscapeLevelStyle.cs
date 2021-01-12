using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarsLandscapeLevelStyle : LevelStyle
{

    protected override void SetBackground()
    {
        GameObject backgroundImage = GameObject.FindGameObjectWithTag("Background");
        backgroundImage.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
