using runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LobbyUI : BaseUI
{

    protected override UIState GetUIState()
    {
        return UIState.Lobby; // �̰� �־�� ����Ŀ� �������̵�
    }
    public Button RunButton;
    public Button exittButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (RunButton != null)
        {
            RunButton.onClick.AddListener(OnRunButtonClicked);
            exittButton.onClick.AddListener(OnExitButtonClicked);

        }
        else
        {
            Debug.LogWarning("RUN Button�� ������� �ʾҽ��ϴ�.");
        }

    }
    public void OnRunButtonClicked()
    {
        Debug.Log("��ư Ŭ����! �� �������� �̵�");
        GameManager.Instance.ChangeState(GameState.InGame);
    }//GameState.InGame
    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR //�� �÷��� ���� �ٸ� �������� ����

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
