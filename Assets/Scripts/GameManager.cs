using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

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
        public void GameOver()
        {
            Debug.Log("게임 오버!");
            // 예: 현재 씬을 다시 로드 (리트라이)
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

