using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameClearScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI bestTimeText;

    public void ShowScore()
    {
        Debug.Log($"[GameClearScoreDisplay] ShowScore ȣ���");
        Debug.Log($"[GameClearScoreDisplay] FinalScore: {ScoreDataBuffer.FinalScore}, FinalTime: {ScoreDataBuffer.FinalTime:F2}");
        finalScoreText.text = $"{ScoreDataBuffer.FinalScore:D4}";
        bestScoreText.text = $"{ScoreManager.GetHighScore():D4}";
        finalTimeText.text = $"{ScoreDataBuffer.FinalTime:F2}s";
        bestTimeText.text = $"{ScoreManager.GetBestTime():F2}s";
    }

    void OnEnable()
    {
        ShowScore();
    }
}

