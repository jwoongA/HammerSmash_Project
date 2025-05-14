using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TMP ������Ʈ ����
    public float elapsedTime = 0f;
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
    private bool hasLogged = false; //�ѹ��� ����� �α� ȣ��
    
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

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int centiseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f); // 1/100��

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, centiseconds);
    }
}