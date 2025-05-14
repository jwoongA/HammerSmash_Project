using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using runner;

public class GameOverUI : BaseUI
{
    public Button restartButton;
    public Button lobbyButton;

    protected override UIState GetUIState()
    {
        return UIState.GameOver; 
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            lobbyButton.onClick.AddListener(OnLobbyButtonClicked);
        }
        else
        {
            Debug.LogWarning("Start Button�� ������� �ʾҽ��ϴ�.");
        }

    }
    public void OnRestartButtonClicked()
    {
        Debug.Log("��ư Ŭ����! �� ���� �����");
        Time.timeScale = 1f;
        GameManager.Instance.ChangeState(GameState.InGame);
    }
   
    public void OnLobbyButtonClicked()
    {
        Debug.Log("��ư Ŭ����! �κ��");
        if (GameManager.Instance == null)
        {
            SceneManager.LoadScene("LobbyScene");
            Debug.LogError("GameManager �ν��Ͻ��� �������� �ʽ��ϴ�!");
        }
        else
        {
            Time.timeScale = 1f;
            GameManager.Instance.ChangeState(GameState.Lobby);
        }
    }
   
}
