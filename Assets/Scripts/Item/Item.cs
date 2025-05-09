using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Magnet,
        SmallHeal,
        LargeHeal,
        FastRun,
        HammerTime
    }

    public ItemType itemType;

    // 임시 테스트용
    private static int tempHP = 50;
    private const int maxHP = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // player.cs 가 생기면 고쳐야 할 부분
        if (!other.CompareTag("Player")) return;
        
            // 추후 구현 예정
            //Player player = other.GetComponent<Player>();
            //if (player != null)
            //{
            //    player.ApplyItemEffect(itemType);
            //}
        

        switch (itemType)
        {
            case ItemType.SmallHeal:
                Debug.Log("소형 체력 물약");
                // 체력 회복 시스템 구현, 10회복
                tempHP += 10;
                break;
                case ItemType.LargeHeal:
                Debug.Log("대형 체력 물약");
                // 체력 회복 시스템 구현, 40회복
                tempHP += 40;
                break;
                case ItemType.FastRun:
                Debug.Log("속도 증가");
                // 속도 증가 2배, 2.2초동안 지속
                break;
            case ItemType.HammerTime:
                Debug.Log("망치 나가신다!");
                // 무적 시간, 3.4초동안 지속
                break;
            case ItemType.Magnet:
                Debug.Log("자석 효과");
                // 자석 효과, 2.8초동안 지속
                break;
            default:
                break;
        }

        // 최대 체력은 넘기지 못하게
        tempHP = Mathf.Min(tempHP, maxHP);

        Debug.Log($"테스트 아이템 {itemType} 획득");

        Destroy(gameObject);
    }
}
