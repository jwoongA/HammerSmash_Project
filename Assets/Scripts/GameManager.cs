using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using runner;


namespace runner
{

    public enum GameState
    {
        Start,
        Lobby,
        InGame,
        GameOver
    }
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameState CurrentState { get; private set; }

        public GameObject gameOverUIPrefab; // 인스펙터에 연결할 게임 오버 UI 프리팹
        private GameObject currentGameOverUI;

        private void Awake()
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

        private void Start()
        {
            ChangeState(GameState.Start);
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;

            switch (newState)
            {
                case GameState.Start:
                    Debug.Log("StartScene으로 이동 중");
                    SceneManager.LoadScene("StartScene");
                    break;
                case GameState.Lobby:
                    Debug.Log("LobbyScene으로 이동 중");
                    SceneManager.LoadScene("LobbyScene");
                    break;
                case GameState.InGame:
                    Debug.Log("Stage1_Scene으로 이동 중");
                    SceneManager.LoadScene("Stage1_Scene");
                    break;
                case GameState.GameOver:
                    Debug.Log("GameOverScene으로 이동 중");
                    SceneManager.LoadScene("GameOverScene");
                    break;
            }
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
}
