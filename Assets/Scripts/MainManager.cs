using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject getReadyButton;
    [SerializeField] private GameObject scoreBoard;
    [SerializeField] private PlayerController player;
    [SerializeField] private PipePool pipePool;

    void Start()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        playButton.SetActive(true);
        getReadyButton.SetActive(true);
        restartButton.SetActive(false);
        gameOver.SetActive(false);
        scoreBoard.SetActive(false);
    }
    public void Play()
    {
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
    public void Restart()
    {
        GameSingleton.instance.Restart();
        pipePool.Restart();
        restartButton.SetActive(false);
        gameOver.SetActive(false);
        scoreBoard.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
    }
}
