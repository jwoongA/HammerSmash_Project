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
        return UIState.GameOver; // ���� UI ���� Enum�� ���� ����
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
        Time.timeScale = 1f;
        Debug.Log("��ư Ŭ����! �� ���� �����");
        GameManager.Instance.ChangeState(GameState.InGame);
    }
   
    public void OnLobbyButtonClicked()
    {
        Time.timeScale = 1f;
        Debug.Log("��ư Ŭ����! �� �κ�� �̵�");
        GameManager.Instance.ChangeState(GameState.Lobby);
    }
   
}
