using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPlaying = true;
    public bool gameOver = false;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;

    }
    void Update()
    {
        
    }
}
