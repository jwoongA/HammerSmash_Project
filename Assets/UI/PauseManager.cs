using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public Button stopButton;

    private bool isPaused = false;

    void Start()
    {
        stopButton.onClick.AddListener(TogglePause);  
    }

    public void TogglePause()
    {
        Debug.Log("���� ��ư ����!");
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("gamestoped");

            // ������ ������ ����
           
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("gamerestarted");

            
        }
    }
}
