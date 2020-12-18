using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject pauseMenu;

    public State GameState;
    public enum State { Title, Pause, Play, End }

    [SerializeField] private int CycleTime = 8;
    [SerializeField] private int prevLevel = -1;
    private int currentSceneIndex;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        GameState = State.Title;
        StartCoroutine("LevelCycle");
    }

    IEnumerator LevelCycle()
    {
        int nextLevel = prevLevel + 1;
        if (nextLevel >= SceneManager.sceneCountInBuildSettings - 2 || nextLevel <= 1)
        {
            nextLevel = 3;
        }
        LoadScene(nextLevel);
        yield return new WaitForSecondsRealtime(CycleTime);
        if (GameState == State.Title)
        {
            StartCoroutine("LevelCycle");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
     
            if (GameState == State.Play)
            {
                GameState = State.Pause;
                pauseMenu.SetActive(true);
            }
            else if (GameState == State.Pause)
            {
                GameState = State.Play;
                pauseMenu.SetActive(false);
            }
            else if (GameState == State.Title)
            {
                Application.Quit();
            }
        }
    }

    public void LoadNextScene()
    {
        currentSceneIndex++;
        LoadScene(currentSceneIndex);
    }
    public void RestartScene() =>
        LoadScene(currentSceneIndex);
    

    public void LoadScene(int index)
    {
        Debug.Log(index);
        if (index == 9)
        {
            AudioManager audioManager = AudioManager.instance;
            audioManager.Play("EndTheme");
            audioManager.mute("LightTheme");
            audioManager.mute("DarkTheme");

        }
        StartCoroutine("TransitionAnimation");
        StartCoroutine("c_LoadScene", index);
    }

    IEnumerator TransitionAnimation()
    {
        // hard coded 2 second transition time XD
        animator.SetTrigger("Fade");
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("hello sir, please transition thank you.");
        animator.ResetTrigger("Fade");
    }

    IEnumerator c_LoadScene(int level)
    {        
        yield return new WaitForSecondsRealtime(0.6f);
        if (prevLevel > 1)
        {
            SceneManager.UnloadSceneAsync(prevLevel);
        }
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        prevLevel = level;
    }

    public void buttonHover()
    {
        AudioManager.instance.Play("HoverButton");
    }

    public void StartButtonClicked()
    {
        AudioManager.instance.Play("ClickButton");
        if (SceneManager.GetSceneByBuildIndex(1) != null)
        {
            SceneManager.UnloadSceneAsync(1);
        }
        LoadScene(2);
        currentSceneIndex = 2;
        GameState = State.Play;
    }

    public void CreditButtonClicked()
    {
        AudioManager.instance.Play("ClickButton");
        if (SceneManager.GetSceneByBuildIndex(1) != null)
        {
            SceneManager.UnloadSceneAsync(1);
        }
        SceneManager.LoadSceneAsync(10, LoadSceneMode.Additive);
    }

    public void ReturnButtonClicked()
    {
        AudioManager.instance.Play("ClickButton");
        if (SceneManager.GetSceneByBuildIndex(10) != null)
        {
            SceneManager.UnloadSceneAsync(10);
        }
        LoadScene(1);
    }


    public void RestartButtonClicked()
    {
        AudioManager.instance.Play("ClickButton");
        if (SceneManager.GetSceneByBuildIndex(prevLevel) != null)
        {
            SceneManager.UnloadSceneAsync(prevLevel);
        }
        LoadScene(currentSceneIndex);
        currentSceneIndex = 1;
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            GameState = State.Play;
        }
        else
        {
            Debug.Log("Trying to set pause menue inactive when already inactive.");
        }
    }

    public void ContinueButtonClicked()
    {
        AudioManager.instance.Play("ClickButton");
        if (GameState == State.Pause)
        {
            if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                GameState = State.Play;
            }
            else
            {
                Debug.Log("Trying to set pause menue inactive when already inactive.");
            }
        }
        else
        {
            Debug.Log("Clicked continue, but game state is: " + GameState);
        }
    }

    public void ExitButtonClicked()
    {
        AudioManager.instance.Play("ClickButton");
        Application.Quit();
    }

    private int getBuildIndexS(int level)
    {
        int result = level + 2;
        if (result >= SceneManager.sceneCountInBuildSettings)
        {
            result = SceneManager.sceneCountInBuildSettings - 1;
        }
        return result;
    }
}
