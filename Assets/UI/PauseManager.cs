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
        Debug.Log("스톱 버튼 눌림!");
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("gamestoped");

            // 에디터 멈추지 않음
           
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("gamerestarted");

            
        }
    }
}
