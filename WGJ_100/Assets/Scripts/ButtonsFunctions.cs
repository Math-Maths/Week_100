using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour {

    [SerializeField] GameObject healthBar, pauseButton, metersObj;
    [SerializeField] Animator camAnimator, mainMenuAnimator;
    AudioListener audioListener;
    SceneController sceneManager;
    GameSaver gameSaver;

    void Start()
    {
        audioListener = FindObjectOfType<AudioListener>();
        gameSaver = FindObjectOfType<GameSaver>();
        sceneManager = GetComponent<SceneController>();
        if (gameSaver.isReturning) {
            PlayGame();
        }
        else
        {
            healthBar.SetActive(false);
            pauseButton.SetActive(false);
            metersObj.SetActive(false);
        }
    }

	public void PlayGame()
    {
        camAnimator.enabled = false;
        mainMenuAnimator.enabled = false;
        sceneManager.StartTheGame();
        healthBar.SetActive(true);
        pauseButton.SetActive(true);
        metersObj.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        audioListener.enabled = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        audioListener.enabled = true;
    }

    public void ReloadScene()
    {
        gameSaver.isReturning = false;
        audioListener.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void InvokeReloadScene()
    {
        Invoke("ReloadScene", 2.5f);
    }

    public void Return()
    {
        gameSaver.isReturning = true;
        audioListener.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
