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
        Debug.Log($" ��������1 ���� �����ϴ� GameManager ��: {allManagers.Length}");

        foreach (var manager in allManagers)
        {
            Debug.Log(" �߰ߵ� GameManager ������Ʈ �̸�: " + manager.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
