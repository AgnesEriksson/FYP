using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPlaying = true;
    public bool gameOver = false;
    [SerializeField] Menus menu;
    [SerializeField] private TextMeshProUGUI FinalScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameOver = false;
        isPlaying = true;
    }

    public void GameOver()
    {
        ScoreManager.Instance.highScoreCheck();
        HighScoreText.text = "High Score: " + ScoreManager.Instance.HighScore;
        FinalScoreText.text = "Score: " + ScoreManager.Instance.FinalScore;
        menu.GameOverActive();
    }
    void Update()
    {
    }

    public void CloseApplication()
    {
        Application.Quit();//closes the app 

#if UNITY_EDITOR //for editor use also makes testing in editor easier
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
