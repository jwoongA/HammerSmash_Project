using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    // 체력 설정
    public int maxHP = 120;
    public int currentHP = 120;

    // 상태 효과
    public bool isInvincible = false;
    public bool isMagnetActive = false;

    // 아이템 종류에 따라 효과를 분기 처리
    public void ApplyItemEffect(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.SmallHeal:
                Heal(10);   // 10 회복
                break;
            case Item.ItemType.LargeHeal:
                Heal(40);   // 40 회복
                break;
            case Item.ItemType.HammerTime:
                StartCoroutine(Invincibility(3.4f));    // 3.4초 무적(망치 나가신다!)
                break;
            case Item.ItemType.Magnet:
                StartCoroutine(MagnetEffect(2.8f));
                break;
            // 추가해야 할 아이템
            // 질주
            // 코인
        }
    }

    // 체력 회복 함수
    private void Heal(int amount)
    {
        // maxHP를 초과해서 회복하지 못하게 막기
        currentHP = Mathf.Min(currentHP + amount, maxHP);
        Debug.Log($"체력 {amount} 회복");
    }

    // 무적 상태 처리 코루틴
    private IEnumerator Invincibility(float duration)
    {
        isInvincible = true;
        Debug.Log("무적 시작");

        // 지속 시간 동안 대기
        yield return new WaitForSeconds(duration);

        isInvincible = false;
        Debug.Log("무적 종료");
    }

    // 자석 효과 코루틴
    private IEnumerator MagnetEffect(float duration)
    {
        isMagnetActive = true;
        Debug.Log("자석 효과 시작");

        yield return new WaitForSeconds(duration);

        isMagnetActive = false;
        Debug.Log("자석 효과 끝");
    }
}
