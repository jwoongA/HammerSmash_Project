using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Start,
    InGame,
    Lobby,
    GameOver,
    Stage1ClearUI,
    GameClear
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
    Stage1ClearUI stage1ClearUI = null;
    GameClearUI gameClearUI = null;

    //TheStack theStack = null;

    private void Awake()
    {
        Debug.Log($"[UI�Ŵ���] ���� �� ���� �� CurrentScore: {ScoreDataBuffer.CurrentScore}");
        Debug.Log("UIManager.Awake(): ȣ���");
        instance = this;

        startUI = GetComponentInChildren<StartUI>(true); //�����ִ� ������Ʈ�� ã�Ƴ��Բ�. Ʈ���.
        startUI?.Init(this);

        ingameUI = GetComponentInChildren<InGameUI>(true);
        ingameUI?.Init(this);

        lobbyUI = GetComponentInChildren<LobbyUI>(true);
        lobbyUI?.Init(this);

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI?.Init(this);

        stage1ClearUI = GetComponentInChildren<Stage1ClearUI>(true);
        stage1ClearUI?.Init(this);

        gameClearUI = GetComponentInChildren<GameClearUI>(true);
        gameClearUI?.Init(this);

        Debug.Log("UIManager.Awake(): UI �ʱ�ȭ �Ϸ�");
        ChangeState(UIState.Start);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        startUI?.SetActive(currentState);
        ingameUI?.SetActive(currentState);
        lobbyUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
        stage1ClearUI?.SetActive(currentState);
        gameClearUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
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