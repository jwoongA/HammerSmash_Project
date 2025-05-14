using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float elapsedTime = 0f;
    private bool hasLogged = false; //�ѹ��� ����� �α� ȣ��

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Stage1_Scene" || currentScene == "Loding2_Scene" || currentScene == "Stage2_Scene")
        {
            elapsedTime = ScoreDataBuffer.CurrentTime;
            Debug.Log($"[GameTimer] ���� �ð� ������: {elapsedTime:F2}s");
        }
        else
        {
            elapsedTime = 0f;
            ScoreDataBuffer.CurrentTime = 0f;
            Debug.Log("[GameTimer] �ð� �ʱ�ȭ��");
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
            Debug.LogWarning("timerText�� ����Ǿ� ���� �ʽ��ϴ�!");
            return;
        }

        if (!hasLogged)
        {
            Debug.Log("GameTimer �۵� ��");
            hasLogged = true;
        }

        elapsedTime += Time.deltaTime;
        ScoreDataBuffer.CurrentTime = elapsedTime; //�������� �̵��ص� �ð� ������

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int centiseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f); // 1/100��

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, centiseconds);
    }
}