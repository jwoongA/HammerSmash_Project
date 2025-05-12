using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; //������
    private Rigidbody2D Playerrigidbody; 
    private Animator animator;

    public int maxJumpCount = 2; //�ִ� ���� Ƚ��
    private int currentJumpCount = 0;

    void Start()
    {
        Playerrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        //����
        if (Input.GetKeyDown(KeyCode.Z) && currentJumpCount < maxJumpCount)
        {
            Playerrigidbody.velocity = new Vector2(Playerrigidbody.velocity.x, jumpForce);
            animator.SetBool("IsJump", true);
            animator.SetBool("IsSliding", false); 
            currentJumpCount++;
        }
        //�����̵�
        else if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("IsSliding", true);
        }
        else
        {
            animator.SetBool("IsSliding", false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //'�׶���' �±׿� �΋H���� ����Ƚ�� �ʱ�ȭ �� ���� �ִϸ��̼� �ʱ�ȭ
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentJumpCount = 0;
            animator.SetBool("IsJump", false); 
        }
    }

}
