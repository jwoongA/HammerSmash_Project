using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerEffect playerEffect;

    void Start()
    {
        if (scoreText != null)
            scoreText.text = "SCORE : 0";
    }

    void Update()
    {
        if (playerEffect != null && scoreText != null)
        {
            scoreText.text = $"{playerEffect.score.ToString("D4")}";



        }
    }
}