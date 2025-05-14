using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    private const string HighScoreKey = "HighScore";
    private const string BestTimeKey = "BestTime";

    public static int GetHighScore() => PlayerPrefs.GetInt(HighScoreKey, 0);
    public static float GetBestTime() => PlayerPrefs.GetFloat(BestTimeKey, 0f);

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

    public static bool TrySetNewBestTime(float time)
    {
        if (time > GetBestTime())
        {
            PlayerPrefs.SetFloat(BestTimeKey, time);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }
}
