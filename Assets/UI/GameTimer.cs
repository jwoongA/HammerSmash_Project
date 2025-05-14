using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TMP 컴포넌트 연결
    public float elapsedTime = 0f;
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
    private bool hasLogged = false; //한번만 디버그 로그 호출
    
    void Update()
     
    {
        
        if (timerText == null)
        {
            Debug.LogWarning("timerText가 연결되어 있지 않습니다!");
            return;
        }

        if (!hasLogged)
        {
            Debug.Log("GameTimer 작동 중");
            hasLogged = true;
        }

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int centiseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f); // 1/100초

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, centiseconds);
    }
}