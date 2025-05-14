using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Stage1ClearTrigger : MonoBehaviour
{
  

    [Header("대상 연결")]
    public Transform playerTransform;       // Player (1)
    public Transform goalTransform;         // Square (GameObject 15 안)
    public GameObject clearUI;              // 클리어 UI 패널

    private bool isCleared = false;
    
    void Start()
    {
        Debug.LogWarning("Start() 실행됨 - 클리어 UI 비활성화 시작");

        if (clearUI != null)
        {
            clearUI.SetActive(false);
            Debug.LogWarning("clearUI.SetActive(false) 호출됨");
        }
        else
        {
            Debug.LogError("clearUI가 인스펙터에서 연결되지 않았습니다!");
        }      // 시작 시 숨김
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCleared) return;

        if (other.CompareTag("Player")) // Player 태그 기준
        {
            isCleared = true;

            Debug.Log("충돌 감지! 스테이지 클리어!");
            Time.timeScale = 0f;

            HandleGameClear();

            if (clearUI != null)
                clearUI.SetActive(true);
        }
    }

    void HandleGameClear()
    {
        var effect = FindObjectOfType<PlayerEffect>();
        var timer = FindObjectOfType<GameTimer>();

        if (effect != null && timer != null)
        {
            ScoreDataBuffer.FinalScore = effect.score;
            ScoreDataBuffer.FinalTime = timer.GetElapsedTime();

            // Stage2로 넘길 값 지정
            ScoreDataBuffer.CurrentScore = ScoreDataBuffer.FinalScore;
            ScoreDataBuffer.CurrentTime = ScoreDataBuffer.FinalTime;

            ScoreManager.TrySetNewHighScore(effect.score);
            ScoreManager.TrySetNewBestTime(timer.GetElapsedTime());

            Debug.Log($"클리어 시점 저장됨! 점수: {effect.score}, 시간: {timer.GetElapsedTime():F2}");
            Debug.Log($"[StageClear] 계승용 CurrentScore 설정 완료: {ScoreDataBuffer.CurrentScore}, {ScoreDataBuffer.CurrentTime:F2}");
        }
    }
}
