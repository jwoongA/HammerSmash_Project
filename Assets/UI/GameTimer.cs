using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float elapsedTime = 0f;
    private bool hasLogged = false; //한번만 디버그 로그 호출

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Stage1_Scene" || currentScene == "Loding2_Scene" || currentScene == "Stage2_Scene")
        {
            elapsedTime = ScoreDataBuffer.CurrentTime;
            Debug.Log($"[GameTimer] 이전 시간 유지됨: {elapsedTime:F2}s");
        }
        else
        {
            elapsedTime = 0f;
            ScoreDataBuffer.CurrentTime = 0f;
            Debug.Log("[GameTimer] 시간 초기화됨");
        }
    }
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
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
        ScoreDataBuffer.CurrentTime = elapsedTime; //스테이지 이동해도 시간 유지용

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int centiseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f); // 1/100초

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, centiseconds);
    }
}