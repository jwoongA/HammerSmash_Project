using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D Playerrigidbody;
    private Animator animator;

    public int maxJumpCount = 2;
    private int currentJumpCount = 0;

    void Start()
    {
        Playerrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.Z) && currentJumpCount < maxJumpCount && !Input.GetKey(KeyCode.X))
        {
            Playerrigidbody.velocity = new Vector2(Playerrigidbody.velocity.x, jumpForce);
            animator.SetBool("IsJump", true);
            currentJumpCount++;
        }
        // 슬라이딩 (X키 누르고 있을 때)
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("IsSliding", true);
        }
        else
        {
            animator.SetBool("IsSliding", false);
        }

        // 떨어질 때 점프 애니메이션 끄기
        if (Playerrigidbody.velocity.y <= 0)
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject); // 태그에'아이템'이 붙어있는 오브젝트와 충돌하면 충돌한 아이템이 사라짐
        }
    }
}
