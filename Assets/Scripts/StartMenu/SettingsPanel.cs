using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public InputField nicknameInputField;
    public Button soundEffectsToggle, musicToggle;

    private Sprite onToggleSprite, offToggleSprite;

    bool soundEffectsEnable, musicEnable;
    string nickname;

    private void Awake()
    {
        onToggleSprite = Resources.Load<Sprite>("Sprites/ToggleButtons/ToggleOn");
        offToggleSprite = Resources.Load<Sprite>("Sprites/ToggleButtons/ToggleOff");

        nickname = PlayerPrefs.GetString("nickname");
        if(nickname != null)
        {
            nicknameInputField.text = nickname;
        }

        soundEffectsEnable = PlayerPrefs.GetInt("sound") == 1;
        musicEnable = PlayerPrefs.GetInt("music") == 1;

        SetSoundEffectsToggleImage();
        SetMusicToggleImage();

    }

    public void NicknameChanged()
    {
        nickname = nicknameInputField.text;
    }

    private void SetSoundEffectsToggleImage()
    {
        if (soundEffectsEnable)
        {
            soundEffectsToggle.GetComponent<Image>().sprite = onToggleSprite;
        }
        else
        {
            soundEffectsToggle.GetComponent<Image>().sprite = offToggleSprite;
        }
    }

    private void SetMusicToggleImage()
    {
        if (musicEnable)
        {
            musicToggle.GetComponent<Image>().sprite = onToggleSprite;
        }
        else
        {
            musicToggle.GetComponent<Image>().sprite = offToggleSprite;
        }
    }

    public void ApplyChanges(GameObject panel)
    {
        PlayerPrefs.SetInt("sound", Convert.ToInt32(soundEffectsEnable));
        PlayerPrefs.SetInt("music", Convert.ToInt32(musicEnable));
        PlayerPrefs.SetString("nickname", nickname);

        GetComponent<StartSceneManager>().BackToStartMenu(panel);
    }

    public void SoundEffectsButtonClick()
    {
         
        soundEffectsEnable = !soundEffectsEnable;
        SetSoundEffectsToggleImage();
        
    }

    public void MusicButtonClick()
    {
        musicEnable = !musicEnable;
        SetMusicToggleImage();
        
    }
}
