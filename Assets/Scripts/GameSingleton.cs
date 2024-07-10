using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton instance { get; private set; }
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject getReadyButton;
    [SerializeField] private PipePool pipePool;
    [SerializeField] private List<GameObject> selectButtons = new List<GameObject>();
    [SerializeField] private GameObject scoreBoard;

    public delegate void ScoreChanged(int newScore, int highScore);
    public event ScoreChanged OnScoreChanged;
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
            player.enabled = false;
            playButton.SetActive(false);
            getReadyButton.SetActive(true);
            restartButton.SetActive(false);
            gameOver.SetActive(false);
            scoreBoard.SetActive(false);
        }
    }
    public void Select()
    {
        foreach (GameObject button in selectButtons)
        {
            button.SetActive(false);
        }
        playButton.SetActive(true);
    }
    public void Play()
    {
        score = 0;
        OnScoreChanged?.Invoke(score, highScore);

        playButton.SetActive(false);
        getReadyButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver()
    {
        restartButton.SetActive(true);
        gameOver.SetActive(true);
        scoreBoard.SetActive(true);

        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void IncreaseScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
        Debug.Log("Score increased to: " + score);
        OnScoreChanged?.Invoke(score, highScore);
    }
    public void Restart()
    {
        score = 0;
        OnScoreChanged?.Invoke(score, highScore);

        player.ResetPlayer();
        pipePool.Restart();

        restartButton.SetActive(false);
        gameOver.SetActive(false);
        scoreBoard.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
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
