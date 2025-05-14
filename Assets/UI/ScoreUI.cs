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
        Debug.Log($"[ScoreUI] ���� �� �̸�: {currentScene}");

        if (currentScene == "Stage1_Scene")
        {
            playerEffect.score = 0;
            ScoreDataBuffer.CurrentScore = 0;
            ScoreDataBuffer.FinalScore = 0;
            ScoreDataBuffer.FinalTime = 0f;
            Debug.Log("[ScoreUI] Stage1 ���� �� ����/�ð� ���� �ʱ�ȭ");
        }

        if (currentScene == "LobbyScene")
        {
            playerEffect.score = 0;
            ScoreDataBuffer.CurrentScore = 0;
            Debug.Log("[ScoreUI] �κ� ���� �� ���� �ʱ�ȭ��");
        }
        else if (currentScene == "Stage1_Scene" || currentScene == "Loding2_Scene" || currentScene == "Stage2_Scene")
        {
            if (ScoreDataBuffer.CurrentScore > 0)
            {
                playerEffect.score = ScoreDataBuffer.CurrentScore;
                Debug.Log($"[ScoreUI] ���� ���� ������: {playerEffect.score}");
            }
            else
            {
                playerEffect.score = 0;
                Debug.Log("[ScoreUI] ���ο� �������� �� ���� �ʱ�ȭ��");
            }
        }
        else
        {
            Debug.Log("[ScoreUI] ���� ��� �� �� �� ���� ����");
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