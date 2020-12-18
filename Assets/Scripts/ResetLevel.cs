using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ResetLevel : MonoBehaviour
{

    protected void Restart()
    {
        Debug.Log("RESTARTING");
        if(AudioManager.instance != null)
            AudioManager.instance.Play("Restart");
        if (GameHandler.Instance != null)
            GameHandler.Instance.RestartScene();
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}