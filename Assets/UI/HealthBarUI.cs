using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public PlayerStatus playerStatus;  // 플레이어 체력 참조
    public Image fillImage;            // Fill 오브젝트의 Image 컴포넌트

    void Update()
    {
        if (playerStatus != null && fillImage != null)
        {
            float fillAmount = playerStatus.currentHP / playerStatus.maxHP;
            fillImage.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }
}