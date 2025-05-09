using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rigidboody2d;
    private Animator animator;

    public int maxJumpCount = 2;
    private int currentJumpCount = 0;

    void Start()
    {
        rigidboody2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentJumpCount < maxJumpCount)
        {
            rigidboody2d.velocity = new Vector2(rigidboody2d.velocity.x, jumpForce);
            animator.SetBool("IsJump", true);
            currentJumpCount++;
        }

        // �Ʒ��� ������ �� �ִϸ��̼� ���� ����
        if (rigidboody2d.velocity.y <= 0)
        {
            animator.SetBool("IsJump", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڿ� ����� �� ���� ī��Ʈ �ʱ�ȭ
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentJumpCount = 0;
        }
    }
}



