using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Stage1ClearTrigger : MonoBehaviour
{
  

    [Header("대상 연결")]
    public Transform playerTransform;       // Player (1)
    public Transform goalTransform;         // Square (GameObject 15 안) / 엑시트 팻말로 바뀜.
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
            {
                clearUI.SetActive(true); // UI 활성화

                //  UI 내 점수표시 컴포넌트를 수동으로 호출
                var display = clearUI.GetComponentInChildren<GameClearScoreDisplay>();
                if (display != null)
                {
                    display.ShowScore(); //  시점 문제 해결 핵심 코드
                    Debug.Log("[Stage1ClearTrigger] ShowScore() 수동 호출 완료");
                }
                else
                {
                    Debug.LogWarning("GameClearScoreDisplay 컴포넌트를 찾을 수 없습니다!");
                }
            }
        }
    }

    void HandleGameClear()
    {
        var effect = FindObjectOfType<PlayerEffect>();
        var timer = FindObjectOfType<GameTimer>();

        if (effect != null && timer != null)
        {
            //  Final 데이터 저장
            ScoreDataBuffer.FinalScore = effect.score;
            ScoreDataBuffer.FinalTime = timer.GetElapsedTime();

            //  Stage3 또는 이후를 위한 계승 데이터도 저장
            ScoreDataBuffer.CurrentScore = ScoreDataBuffer.FinalScore;
            ScoreDataBuffer.CurrentTime = ScoreDataBuffer.FinalTime;

            ScoreManager.TrySetNewHighScore(effect.score);
            ScoreManager.TrySetNewBestTime(timer.GetElapsedTime());

            Debug.Log($"[Stage1ClearTrigger] 클리어 시점 저장됨 → 점수: {effect.score}, 시간: {timer.GetElapsedTime():F2}");
        }
        else
        {
            Debug.LogWarning("PlayerEffect 또는 GameTimer를 찾지 못했습니다.");
        }
    }
}
