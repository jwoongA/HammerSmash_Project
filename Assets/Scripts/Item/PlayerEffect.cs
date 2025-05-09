using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    // 체력 설정
    public int maxHP = 120;
    public int currentHP = 120;

    // 상태 효과
    public bool isInvincible = false;   // 무적 효과
    public bool isMagnetActive = false;    // 자석 효과
    public bool ignoreHole = false;    // 구멍 무시 효과

    // 투명 플랫폼
    public GameObject invisiblePlatform;

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
                StartCoroutine(MagnetEffect(2.8f));    // 2.8초 자석효과
                break;
            case Item.ItemType.FastRun:
                StartCoroutine(SpeedBoost(2.2f));   // 2.2초 질주효과
                break;
            case Item.ItemType.Coin:
                // 점수 추가
                break;
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

    // 장애물에 적어야 되는 부분 무적 처리
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        var effect = other.GetComponent<PlayerEffect>();
    //        if (effect != null && effect.isInvincible)
    //        {
    //            Destroy(gameObject); // 장애물 파괴
    //            return;
    //        }

    //        // 일반 피격 처리
    //        Debug.Log("플레이어가 장애물에 닿음!");
    //    }
    //}

    // 자석 효과 코루틴
    private IEnumerator MagnetEffect(float duration)
    {
        isMagnetActive = true;
        Debug.Log("자석 효과 시작");

        yield return new WaitForSeconds(duration);

        isMagnetActive = false;
        Debug.Log("자석 효과 끝");
    }

    // 속도 증가 코루틴
    private IEnumerator SpeedBoost(float duration)
    {
        ObstacleMover.globalSpeedMultiplier = 2f;
        isInvincible = true;
        ignoreHole = true;
        if (invisiblePlatform != null)
            invisiblePlatform.SetActive(true);
        Debug.Log("질주 시작");

        yield return new WaitForSeconds(duration);

        ObstacleMover.globalSpeedMultiplier = 1f;
        isInvincible = false;
        ignoreHole = false;
        if (invisiblePlatform != null)
            invisiblePlatform.SetActive(false);                           
        Debug.Log("질주 끝");
    }
}
