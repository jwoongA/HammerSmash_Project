using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxHP = 100f;              
    public float currentHP;                  
    public float hpDecreaseRate = 5f;        // �ʴ� ���ҵǴ� ü�·�

    private Animator animator;               
    private bool isTakingDamage = false;    

    void Start()
    {
        currentHP = maxHP;                 
        animator = GetComponentInChildren<Animator>(); 
    }
    void Update()
    {
        // �ð��� ������ ���� ü�� ����
        currentHP -= hpDecreaseRate * Time.deltaTime;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        if (isTakingDamage) return; // ���� ���¸� ����

        currentHP -= damage;        // ü�� ����
        isTakingDamage = true;      // ���� ���·� ����

        if (animator != null)
            animator.SetBool("IsDamage", true);

        Invoke("EndDamage", 0.5f); // �����ð� 0.5��

        if (currentHP <= 0)
        {
            Die();
        }
    }
    void EndDamage() // ������ �� �� �������� ����
    {
        if (animator != null)
            animator.SetBool("IsDamage", false);
        isTakingDamage = false;
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.CompareTag("�±� ����")) // ��ֹ��� �±� �ο��ؼ� Ư�� �±׿� ������ ������ ����
        //{
            //GetComponent<PlayerStatus>()?.TakeDamage(20f); // �ִ� 5�� �浹�� ���
        //}
    //}
    void Die()
    {
        Debug.Log("�����UI �������");
    }
}


