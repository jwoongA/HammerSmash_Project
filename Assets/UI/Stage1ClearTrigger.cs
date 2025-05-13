using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Stage1ClearTrigger : MonoBehaviour
{
  

    [Header("��� ����")]
    public Transform playerTransform;       // Player (1)
    public Transform goalTransform;         // Square (GameObject 15 ��)
    public GameObject clearUI;              // Ŭ���� UI �г�

    private bool isCleared = false;
    
    void Start()
    {
        Debug.LogWarning("Start() ����� - Ŭ���� UI ��Ȱ��ȭ ����");

        if (clearUI != null)
        {
            clearUI.SetActive(false);
            Debug.LogWarning("clearUI.SetActive(false) ȣ���");
        }
        else
        {
            Debug.LogError("clearUI�� �ν����Ϳ��� ������� �ʾҽ��ϴ�!");
        }      // ���� �� ����
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCleared) return;

        if (other.CompareTag("Player")) // Player �±� ����
        {
            isCleared = true;

            Debug.Log("�浹 ����! �������� Ŭ����!");
            Time.timeScale = 0f;

            if (clearUI != null)
                clearUI.SetActive(true);
        }
    }

   
}
