using runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var allManagers = GameObject.FindObjectsOfType<GameManager>(true);
        Debug.Log($" 스테이지1 씬에 존재하는 GameManager 수: {allManagers.Length}");

        foreach (var manager in allManagers)
        {
            Debug.Log(" 발견된 GameManager 오브젝트 이름: " + manager.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
