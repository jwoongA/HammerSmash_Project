using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Start,
    InGame,
    Lobby,
    GameOver
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    UIState currentState = UIState.Start;

    StartUI startUI = null;
    InGameUI ingameUI = null;
    LobbyUI lobbyUI = null;
    GameOverUI gameOverUI = null;

    //TheStack theStack = null;

    private void Awake()
    {
        Debug.Log("����");
        instance = this;
       // theStack = FindObjectOfType<TheStack>();

        startUI = GetComponentInChildren<StartUI>(true); //�����ִ� ������Ʈ�� ã�Ƴ��Բ�. Ʈ���.
        startUI?.Init(this);

        ingameUI = GetComponentInChildren<InGameUI>(true);
       // ingameUI?.Init(this);

        lobbyUI = GetComponentInChildren<LobbyUI>(true);
        lobbyUI?.Init(this);

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI?.Init(this);

        ChangeState(UIState.Start);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        startUI?.SetActive(currentState);
      //  ingameUI?.SetActive(currentState);
        lobbyUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
     //   theStack.Restart(); //���� ����� �ڵ�
        ChangeState(UIState.InGame);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void UpdateLobby()
    {
     //   ingameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetLobbyUI()
    {
      //  lobbyUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
        ChangeState(UIState.Lobby);
    }
}