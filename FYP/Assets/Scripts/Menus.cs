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
    }

    public void Home()
    {
        SceneSwitcher.LoadSceneByName("MainMenu");
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
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
    }
}
