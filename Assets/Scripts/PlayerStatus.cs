using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public float hpDecreaseRate = 5f; // 초당 감소할 HP량

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        // 시간 경과에 따라 HP 감소
        currentHP -= hpDecreaseRate * Time.deltaTime;

        // HP가 0 이하가 되면 사망
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    void Die()
    {
        //캐릭터 죽으면 UI호출
    }
}

