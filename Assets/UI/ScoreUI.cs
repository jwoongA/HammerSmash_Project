using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerEffect playerEffect;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Stage1_Scene" || currentScene == "Loding2_Scene" || currentScene == "Stage2_Scene")
        {
            if (ScoreDataBuffer.CurrentScore > 0)
            {
                playerEffect.score = ScoreDataBuffer.CurrentScore;
                Debug.Log($"[ScoreUI] 이전 점수 유지됨: {playerEffect.score}");
            }
            else
            {
                playerEffect.score = 0;
                Debug.Log("[ScoreUI] 새로운 스테이지 → 점수 초기화됨");
            }
        }
        else
        {
            playerEffect.score = 0;
            ScoreDataBuffer.CurrentScore = 0;
            Debug.Log("[ScoreUI] 다른 씬 진입 → 점수 초기화됨");
        }

        if (scoreText != null)
        {
            scoreText.text = "SCORE : 0";
        }
    }

    void Update()
    {
        if (playerEffect != null && scoreText != null)
        {
            scoreText.text = $"{playerEffect.score.ToString("D4")}";
            ScoreDataBuffer.CurrentScore = playerEffect.score;
        }
    }
}