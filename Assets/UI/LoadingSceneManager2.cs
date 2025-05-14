using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager2 : MonoBehaviour
{
    public string nextSceneName = "Stage2_Scene"; // 이동할 진짜 게임 씬
    public float waitSeconds = 2f;

    void Start()
    {
        Debug.Log($"[ScoreUI - 로딩2] 진입 시 CurrentScore: {ScoreDataBuffer.CurrentScore}");
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(nextSceneName);
    }
}
