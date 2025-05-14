using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ScoreManager
{
    private const string HighScoreKey = "HighScore";

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public static bool TrySetNewHighScore(int score)
    {
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }
}