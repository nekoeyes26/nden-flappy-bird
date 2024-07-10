using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action<int, int> OnScoreChanged;

    public static void ScoreChanged(int newScore, int highScore)
    {
        OnScoreChanged?.Invoke(newScore, highScore);
    }
}
