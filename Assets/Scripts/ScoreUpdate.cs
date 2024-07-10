using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUpdate : MonoBehaviour
{
    public Text scoreText;
    public Text newScoreText;
    public Text highScoreText;
    void Awake()
    {
        scoreText.text = "";
    }
    void OnEnable()
    {
        StartCoroutine(TrySubscribe());
        // if (GameSingleton.instance != null)
        // {
        //     GameSingleton.instance.OnScoreChanged += HandleScoreChanged;
        //     Debug.Log("Subscribed to OnScoreChanged event.");
        // }
    }

    private void HandleScoreChanged(int newScore, int highScore)
    {
        Debug.Log("Handling score change. New score: " + newScore);
        scoreText.text = newScore.ToString();
        newScoreText.text = newScore.ToString();
        highScoreText.text = highScore.ToString();
    }

    private IEnumerator TrySubscribe()
    {
        while (GameSingleton.instance == null)
        {
            yield return new WaitForSeconds(0.1f);
        }

        GameSingleton.instance.OnScoreChanged += HandleScoreChanged;
        // scoreText.text = "0";
        Debug.Log("Subscribed to OnScoreChanged event.");
    }
}
