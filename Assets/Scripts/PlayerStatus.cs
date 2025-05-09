using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public float hpDecreaseRate = 5f; // �ʴ� ������ HP��

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        // �ð� ����� ���� HP ����
        currentHP -= hpDecreaseRate * Time.deltaTime;

        // HP�� 0 ���ϰ� �Ǹ� ���
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    void Die()
    {
        //ĳ���� ������ UIȣ��
    }
}

