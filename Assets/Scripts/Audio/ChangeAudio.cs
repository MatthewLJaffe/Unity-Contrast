using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour//, IDimensionInteraction
{
    /*
    [SerializeField] public AudioManager audioManager;

    private void Awake()
    {
        ChangeDimension.OnDimensionChange += DimensionInteraction;
    }

    public void DimensionInteraction(bool darken)
    {
        if (darken == true)
        {
            updateTheme("DarkTheme", "LightTheme");
        }
        else
        {
            updateTheme("LightTheme", "DarkTheme");
        }
    }

    private void updateTheme(string themeOn, string themeOff)
    {

        Sound on = Array.Find(audioManager.sounds, sound => sound.name == themeOn);
        on.volume = 1;
        on.source.volume = 1;
        Debug.Log(themeOn + ": SET " + on.volume + " Sourc" + on.source.volume);
        Sound off = Array.Find(audioManager.sounds, sound => sound.name == themeOff);
        off.volume = 0;
        off.source.volume = 0;
        Debug.Log(themeOff + ": SET " + off.volume + " Sourc" + off.source.volume);
    }
    */
}
