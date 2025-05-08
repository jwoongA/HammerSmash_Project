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
        // player.cs �� ����� ���ľ� �� �κ�
        if (!other.CompareTag("Player")) return;
        {
            // ���� ���� ����
            //Player player = other.GetComponent<Player>();
            //if (player != null)
            //{
            //    player.ApplyItemEffect(itemType);
            //}
        }

        switch (itemType)
        {
            case ItemType.SmallHeal:
                Debug.Log("���� ü�� ����");
                // ü�� ȸ�� �ý��� ����
                break;
                case ItemType.LargeHeal:
                Debug.Log("���� ü�� ����");
                // ü�� ȸ�� �ý��� ����
                break;
                case ItemType.FastRun:
                Debug.Log("�ӵ� ����");
                // �ӵ� ����
                break;
            case ItemType.Giant:
                Debug.Log("Ŀ���鼭 ����");
                break;
            case ItemType.Magnet:
                Debug.Log("�ڼ� ȿ��");
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }
}
