using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; //점프력
    private Rigidbody2D Playerrigidbody;
    private Animator animator;

    public int maxJumpCount = 2; //최대 점프 횟수
    private int currentJumpCount = 0;

    private PlayerStatus playerStatus;

    void Start()
    {
        Playerrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        playerStatus = GetComponent<PlayerStatus>();
        if (playerStatus == null)
        {

        }
    }

    void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.Z) && currentJumpCount < maxJumpCount)
        {
            Playerrigidbody.velocity = new Vector2(Playerrigidbody.velocity.x, jumpForce);
            animator.SetBool("IsJump", true);
            animator.SetBool("IsSliding", false);
            currentJumpCount++;
        }
        // 슬라이딩
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    currentJumpCount = 0;
                    animator.SetBool("IsJump", false);
                    break;
                }
            }
        }
    }
}