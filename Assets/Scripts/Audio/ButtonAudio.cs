using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class ButtonAudio : EventTrigger
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.Play("HoverButton");
    }

    public void playAudio(string name)
    {
        AudioManager.instance.Play(name);
    }
}
