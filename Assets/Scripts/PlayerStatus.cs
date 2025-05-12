using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxHP = 100f;              
    public float currentHP;                  
    public float hpDecreaseRate = 5f;        // 초당 감소되는 체력량

    private Animator animator;               
    private bool isTakingDamage = false;    

    void Start()
    {
        currentHP = maxHP;                 
        animator = GetComponentInChildren<Animator>(); 
    }
    void Update()
    {
        // 시간이 지남에 따라 체력 감소
        currentHP -= hpDecreaseRate * Time.deltaTime;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        if (isTakingDamage) return; // 무적 상태면 무시

        currentHP -= damage;        // 체력 감소
        isTakingDamage = true;      // 무적 상태로 설정

        if (animator != null)
            animator.SetBool("IsDamage", true);

        Invoke("EndDamage", 0.5f); // 무적시간 0.5초

        if (currentHP <= 0)
        {
            Die();
        }
    }
    void EndDamage() // 데미지 이 후 무적판정 제거
    {
        if (animator != null)
            animator.SetBool("IsDamage", false);
        isTakingDamage = false;
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.CompareTag("태그 미정")) // 장애물에 태그 부여해서 특정 태그와 닿으면 데미지 판정
        //{
            //GetComponent<PlayerStatus>()?.TakeDamage(20f); // 최대 5번 충돌시 사망
        //}
    //}
    void Die()
    {
        Debug.Log("사망시UI 재생예정");
    }
}


