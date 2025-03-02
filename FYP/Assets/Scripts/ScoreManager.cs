using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public float PlayingScore = 0f;
    public int HighScore = 0;
    public int FinalScore =0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PlayingScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            PlayingScore += Time.fixedDeltaTime;// fixed delta so not hardware dependent 
            scoreText.text = "Score: " + RoundedScore(); // updates score ui to match score to nearest int
        }
        if(!GameManager.Instance.isPlaying && GameManager.Instance.gameOver)// if not playing and game over calls GameOver Protical
        {
            FinalScore = intScore(PlayingScore);
            GameManager.Instance.GameOver();
        }
    }

    public void highScoreCheck()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0); //gets playperf stored highscore
        if (PlayingScore> HighScore) //if play score is higher than highscore replaces the value
        {
            HighScore = intScore(PlayingScore);
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
        else
        {
            HighScore = PlayerPrefs.GetInt("HighScore", 0);
        }
    }

    public void resetHighScore()//for testing may be implemented to remove other players highScores
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    private int intScore(float score)//to make a float an int specifically for HSC
    {
        return Mathf.FloorToInt(score);
    }
    private string RoundedScore()//Nicer for Ui 
    {
        return Mathf.RoundToInt(PlayingScore).ToString();
    }
}
