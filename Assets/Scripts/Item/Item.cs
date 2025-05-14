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
        HammerTime,
        Coin
    }
    public ItemType itemType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // player 오브젝트에 부착된 PlayerEffect 컴포넌트에 효과 적용 요청
        if (!other.CompareTag("Player")) return;

        PlayerEffect effect = other.GetComponent<PlayerEffect>();
        if (effect != null )
        {
            effect.ApplyItemEffect(itemType);
        }

        // 사운드 재생 요청 (아이템 사운드에게)
        if (ItemSound.Instance != null)
        {
            ItemSound.Instance.PlaySound(itemType);
        }

        // 아이템은 획득 후 제거
        Destroy(gameObject);
    }
}
