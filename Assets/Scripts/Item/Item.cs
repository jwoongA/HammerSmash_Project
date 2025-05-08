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
                // ü�� ȸ�� �ý��� ����, 10ȸ��
                break;
                case ItemType.LargeHeal:
                Debug.Log("���� ü�� ����");
                // ü�� ȸ�� �ý��� ����, 40ȸ��
                break;
                case ItemType.FastRun:
                Debug.Log("�ӵ� ����");
                // �ӵ� ���� 2��, 2.2�ʵ��� ����
                break;
            case ItemType.HammerTime:
                Debug.Log("��ġ �����Ŵ�!");
                // ���� �ð�, 3.4�ʵ��� ����
                break;
            case ItemType.Magnet:
                Debug.Log("�ڼ� ȿ��");
                // �ڼ� ȿ��, 2.8�ʵ��� ����
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }
}
