using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum GameState
{
    Start,
    Lobby,
    InGame,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    public GameObject gameOverUIPrefab; // 인스펙터에 연결할 게임 오버 UI 프리팹
    private GameObject currentGameOverUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        
        

    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Debug.Log("중복 GameManager 발견 → 삭제됨");
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //    Debug.Log("GameManager 생성 + 생존 등록");
    //}

    private void Start()
    {
        //ChangeState(GameState.Start);
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            ChangeState(GameState.Start);
        }
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        string targetScene = "";

        switch (newState)
        {
            case GameState.Start:
                Debug.Log("StartScene으로 이동 중");
                targetScene = "StartScene";
                break;
            case GameState.Lobby:
                Debug.Log("LobbyScene으로 이동 중");
                targetScene = "LobbyScene";
                break;
            case GameState.InGame:
                Debug.Log("Loding1_Scene으로 이동 중");
                targetScene = "Loding1_Scene"; // 기존 Stage1_Scene → 변경
                break;
            case GameState.GameOver:
                Debug.Log("GameOverScene으로 이동 중");
                targetScene = "GameOverScene";
                break;
        }
        Debug.Log($"{newState} → {targetScene} 로 이동 중");
        SceneManager.LoadScene(targetScene);
        //Stage1_Scene
    }

    public void GameOver()
    {
        Debug.Log("게임 오버!");
        Time.timeScale = 0f; // 게임 정지
        if (gameOverUIPrefab != null && currentGameOverUI == null)
        {
            currentGameOverUI = Instantiate(gameOverUIPrefab);
        }
        // 예: 현재 씬을 다시 로드 (리트라이)
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
