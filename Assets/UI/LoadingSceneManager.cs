using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public string nextSceneName = "Stage1_Scene"; // 이동할 진짜 게임 씬
    public float waitSeconds = 1.5f;

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(nextSceneName);
    }
}