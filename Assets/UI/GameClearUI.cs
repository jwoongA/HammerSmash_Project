using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearUI : BaseUI
{
    
    public Button lobbyButton;
    protected override UIState GetUIState()
    {
        return UIState.Stage1ClearUI;
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (lobbyButton != null)
        {
           // nextButton.onClick.AddListener(OnNextButtonClicked);
            lobbyButton.onClick.AddListener(OnLobbyButtonClicked);
        }
        else
        {
            Debug.LogWarning("Start Button�� ������� �ʾҽ��ϴ�.");
        }

    }
    //public void OnNextButtonClicked()
    //{
    //    Debug.Log("��ư Ŭ����! �� ���� ����������");
    //    Time.timeScale = 1f;
    //    GameManager.Instance.ChangeState(GameState.Stage1Clear);
    //}

    public void OnLobbyButtonClicked()
    {
        Debug.Log("��ư Ŭ����! �κ��");
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager �ν��Ͻ��� �������� �ʽ��ϴ�!");
        }
        else
        {
            Time.timeScale = 1f;
            GameManager.Instance.ChangeState(GameState.Lobby);
        }
    }

}
