using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public float PlayingScore = 0f;
    public int HighScore = 0;
    private int score;
    private float timer = 0f;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            PlayingScore += Time.fixedDeltaTime;// fixed delta so not hardware dependent 
        }
        if(!GameManager.Instance.isPlaying && GameManager.Instance.gameOver)// if not playing and game over clears the score
        {
            highScoreCheck();
            PlayingScore = 0;
        }
    }

    private void highScoreCheck()
    {
        PlayerPrefs.GetInt("HighScore", 0);
        if (PlayingScore> HighScore)
        {
            HighScore = intScore(PlayingScore);
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    private int intScore(float score)
    {
        return Mathf.FloorToInt(score);
    }
    private string RoundedScore()
    {
        return Mathf.RoundToInt(PlayingScore).ToString();
    }
}
