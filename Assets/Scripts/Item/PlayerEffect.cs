using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    // 플레이어 체력
    private PlayerStatus status;

    [Header("아이템 효과")]
    // 상태 효과
    public bool isInvincible = false;   // 무적 효과
    public bool isMagnetActive = false;    // 자석 효과
    public bool ignoreHole = false;    // 구멍 무시 효과

    [Header("투명 발판(구멍낙사 방지)")]
    // 투명 플랫폼
    public GameObject invisiblePlatform;

    [Header("휘두르는 망치 오브젝트")]
    // 무적 망치 연출
    public GameObject hammerObject;

    private Coroutine invincibleCoroutine;
    private Coroutine magnetCoroutine;
    private Coroutine speedCoroutine;

    public int score = 0;

    private void Awake()
    {
        if (status == null)
            status = GetComponent<PlayerStatus>();
    }

    // 아이템 종류에 따라 효과를 분기 처리
    public void ApplyItemEffect(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.SmallHeal:
                Heal(10);   // 10 회복
                AddScore(10);
                break;
            case Item.ItemType.LargeHeal:
                Heal(40);   // 40 회복
                AddScore(50);
                break;
            case Item.ItemType.HammerTime:
                if (invincibleCoroutine != null)
                    StopCoroutine(invincibleCoroutine);
                invincibleCoroutine = StartCoroutine(Invincibility(3.4f));    // 3.4초 무적(망치 나가신다!)
                break;
            case Item.ItemType.Magnet:
                if (magnetCoroutine != null)
                    StopCoroutine(magnetCoroutine);
                magnetCoroutine = StartCoroutine(MagnetEffect(2.8f));    // 2.8초 자석효과
                break;
            case Item.ItemType.FastRun:
                if (speedCoroutine != null)
                    StopCoroutine(speedCoroutine);
                speedCoroutine = StartCoroutine(SpeedBoost(2.2f));   // 2.2초 질주효과
                break;
            case Item.ItemType.Coin:
                AddScore(100);
                break;
        }
    }

    // 체력 회복 함수
    private void Heal(int amount)
    {
        if (status != null)
        {
            status.currentHP = Mathf.Min(status.currentHP + amount, status.maxHP);
            Debug.Log($"체력 {amount} 회복");
        }
    }

    // 무적 상태 처리 코루틴
    private IEnumerator Invincibility(float duration)
    {
        isInvincible = true;
        if (hammerObject != null)
        {
            hammerObject.SetActive(true);
        }
        Debug.Log("무적 시작");

        // 지속 시간 동안 대기
        yield return new WaitForSeconds(duration);

        isInvincible = false;
        if (hammerObject != null)
        {
            hammerObject.SetActive(false);
        }
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

    // 점수
    public void AddScore(int addscore)
    {
        score += addscore;
        Debug.Log($"점수 {addscore} 획득");
    }
}
