using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour, IDimensionInteraction
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        ChangeDimension.OnDimensionChange += DimensionInteraction;
    }

    private void Start()
    {
        Play("LightTheme");
        Play("DarkTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        //Debug.Log("PLAYING AUDIO CLIP: " + name);
        s.source.Play();
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

        Sound on = Array.Find(sounds, sound => sound.name == themeOn);
        //Debug.Log(on);
        on.source.volume = 1;
        Sound off = Array.Find(sounds, sound => sound.name == themeOff);
        off.source.volume = 0;
    }

    public void mute(string song)
    {
        Sound on = Array.Find(sounds, sound => sound.name == song);
        //Debug.Log(on);
        on.source.mute = true;
    }
}
