using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Stage1ClearTrigger : MonoBehaviour
{
  

    [Header("��� ����")]
    public Transform playerTransform;       // Player (1)
    public Transform goalTransform;         // Square (GameObject 15 ��) / ����Ʈ �ָ��� �ٲ�.
    public GameObject clearUI;              // Ŭ���� UI �г�

    private bool isCleared = false;
    
    void Start()
    {
        Debug.LogWarning("Start() ����� - Ŭ���� UI ��Ȱ��ȭ ����");

        if (clearUI != null)
        {
            clearUI.SetActive(false);
            Debug.LogWarning("clearUI.SetActive(false) ȣ���");
        }
        else
        {
            Debug.LogError("clearUI�� �ν����Ϳ��� ������� �ʾҽ��ϴ�!");
        }      // ���� �� ����
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCleared) return;

        if (other.CompareTag("Player")) // Player �±� ����
        {
            isCleared = true;

            Debug.Log("�浹 ����! �������� Ŭ����!");
            Time.timeScale = 0f;

            HandleGameClear();

            if (clearUI != null)
            {
                clearUI.SetActive(true); // UI Ȱ��ȭ

                //  UI �� ����ǥ�� ������Ʈ�� �������� ȣ��
                var display = clearUI.GetComponentInChildren<GameClearScoreDisplay>();
                if (display != null)
                {
                    display.ShowScore(); //  ���� ���� �ذ� �ٽ� �ڵ�
                    Debug.Log("[Stage1ClearTrigger] ShowScore() ���� ȣ�� �Ϸ�");
                }
                else
                {
                    Debug.LogWarning("GameClearScoreDisplay ������Ʈ�� ã�� �� �����ϴ�!");
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
            //  Final ������ ����
            ScoreDataBuffer.FinalScore = effect.score;
            ScoreDataBuffer.FinalTime = timer.GetElapsedTime();

            //  Stage3 �Ǵ� ���ĸ� ���� ��� �����͵� ����
            ScoreDataBuffer.CurrentScore = ScoreDataBuffer.FinalScore;
            ScoreDataBuffer.CurrentTime = ScoreDataBuffer.FinalTime;

            ScoreManager.TrySetNewHighScore(effect.score);
            ScoreManager.TrySetNewBestTime(timer.GetElapsedTime());

            Debug.Log($"[Stage1ClearTrigger] Ŭ���� ���� ����� �� ����: {effect.score}, �ð�: {timer.GetElapsedTime():F2}");
        }
        else
        {
            Debug.LogWarning("PlayerEffect �Ǵ� GameTimer�� ã�� ���߽��ϴ�.");
        }
    }
}
