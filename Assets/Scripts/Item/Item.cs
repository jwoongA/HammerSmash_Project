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
        Giant
    }

    public ItemType itemType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // player.cs 가 생기면 고쳐야 할 부분
        if (!other.CompareTag("Player")) return;
        {
            // 추후 구현 예정
            //Player player = other.GetComponent<Player>();
            //if (player != null)
            //{
            //    player.ApplyItemEffect(itemType);
            //}
        }

        switch (itemType)
        {
            case ItemType.SmallHeal:
                Debug.Log("소형 체력 물약");
                // 체력 회복 시스템 구현
                break;
                case ItemType.LargeHeal:
                Debug.Log("대형 체력 물약");
                // 체력 회복 시스템 구현
                break;
                case ItemType.FastRun:
                Debug.Log("속도 증가");
                // 속도 증가
                break;
            case ItemType.Giant:
                Debug.Log("커지면서 무적");
                break;
            case ItemType.Magnet:
                Debug.Log("자석 효과");
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }
}
