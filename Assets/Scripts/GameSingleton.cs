using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton instance { get; private set; }
    private int score;
    private int highScore;
    private BirdScriptable bird;
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Time.timeScale = 0f;
        }
    }
    public void Play()
    {
        score = 0;
        GameEvents.ScoreChanged(score, highScore);
    }
    public void IncreaseScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
        Debug.Log("Score increased to: " + score);
        GameEvents.ScoreChanged(score, highScore);
    }
    public void Restart()
    {
        score = 0;
        GameEvents.ScoreChanged(score, highScore);
    }
    public void assignBird(BirdScriptable newBird)
    {
        bird = newBird;
    }
    public BirdScriptable getBird()
    {
        return bird;
    }
}
