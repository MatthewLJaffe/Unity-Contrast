using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EndAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        AudioManager audioManager = AudioManager.instance;
        audioManager.mute("LightTheme");
        audioManager.mute("DarkTheme");
    }
}
