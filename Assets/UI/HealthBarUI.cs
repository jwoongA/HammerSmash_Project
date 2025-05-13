using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public PlayerStatus playerStatus;  // �÷��̾� ü�� ����
    public Image fillImage;            // Fill ������Ʈ�� Image ������Ʈ

    void Update()
    {
        if (playerStatus != null && fillImage != null)
        {
            float fillAmount = playerStatus.currentHP / playerStatus.maxHP;
            fillImage.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }
}