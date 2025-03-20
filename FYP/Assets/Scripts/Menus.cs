using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject volumeMenu;
    [SerializeField]
    GameObject GameOverMenu;
    [SerializeField]
    SceneSwitcher SceneSwitcher;
    [SerializeField]
    VolumeManager volumeController;

    void Start()
    {
        volumeController.HandleAudio();
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.isPlaying = false;
    }

    public void Home()
    {
        SceneSwitcher.LoadSceneByName("MainMenu");
        Time.timeScale = 1f;
        GameManager.Instance.isPlaying = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.isPlaying = true;
        Debug.Log("resume");
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
        GameManager.Instance.isPlaying = true;
    }

    public void Quit()
    {
        GameManager.Instance.CloseApplication();
    }

    public void GameOverActive()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        GameOverMenu.SetActive(true);
    }
    public void GameOverInactive()
    {
        Time.timeScale = 1f;
        GameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void VolumeActive()
    {
        Time.timeScale = 0f; ;
        volumeMenu.SetActive(true);
        volumeController.HandleAudio();
    }

    public void VolumeInactive()
    {
        Time.timeScale = 0f;
        volumeController.SaveSettings();
        volumeMenu.SetActive(false);
        Debug.Log("volume");
    }
}
