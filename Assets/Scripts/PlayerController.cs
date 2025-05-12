using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D playrigidboody;
    private Animator animator;

    public int maxJumpCount = 2;
    private int currentJumpCount = 0;

    void Start()
    {
        playrigidboody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // ����
        if (Input.GetKeyDown(KeyCode.Z) && currentJumpCount < maxJumpCount && !Input.GetKey(KeyCode.X))
        {
            playrigidboody.velocity = new Vector2(playrigidboody.velocity.x, jumpForce);
            animator.SetBool("IsJump", true);
            currentJumpCount++;
        }

        // �����̵� (XŰ ������ ���� ��)
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("IsSliding", true);
        }
        else
        {
            animator.SetBool("IsSliding", false);
        }

        // ������ �� ���� �ִϸ��̼� ����
        if (playrigidboody.velocity.y <= 0)
        {
            animator.SetBool("IsJump", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentJumpCount = 0;
        }
    }
}
