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
        Debug.Log($"[ScoreUI] 현재 씬 이름: {currentScene}");

        if (currentScene == "Stage1_Scene")
        {
            playerEffect.score = 0;
            ScoreDataBuffer.CurrentScore = 0;
            ScoreDataBuffer.FinalScore = 0;
            ScoreDataBuffer.FinalTime = 0f;
            Debug.Log("[ScoreUI] Stage1 진입 → 점수/시간 완전 초기화");
        }

        if (currentScene == "LobbyScene")
        {
            playerEffect.score = 0;
            ScoreDataBuffer.CurrentScore = 0;
            Debug.Log("[ScoreUI] 로비 진입 → 점수 초기화됨");
        }
        else if (currentScene == "Stage1_Scene" || currentScene == "Loding2_Scene" || currentScene == "Stage2_Scene")
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
            Debug.Log("[ScoreUI] 유지 대상 외 씬 → 점수 유지");
        }

        //if (scoreText != null && playerEffect != null)
        //{
        //    scoreText.text = $"{playerEffect.score.ToString("D4")}";
        //}
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