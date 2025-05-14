using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI bestTimeText;

    public void ShowScore()
    {
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
