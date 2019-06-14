using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour {

    [SerializeField] GameObject healthBar, pauseButton, metersObj;
    [SerializeField] RectTransform mainMenu;
    SceneController sceneManager;

    void Start()
    {
        sceneManager = GetComponent<SceneController>();
        healthBar.SetActive(false);
        pauseButton.SetActive(false);
        metersObj.SetActive(false);
    }

	public void PlayGame()
    {
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
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void InvokeReloadScene()
    {
        Invoke("ReloadScene", 2.5f);
    }

}
