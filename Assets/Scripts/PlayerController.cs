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

    public AudioClip firstJumpSound; // 1단 점프 소리
    public AudioClip doubleJumpSound; // 2단 점프 소리
    private AudioSource audioSource;

    public AudioClip slidingSound; // 슬라이딩 소리
    private bool hasPlayedSlidingSound = false;

    void Start()
    {
        Playerrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

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

            // 점프 횟수에 따라 다른 소리 재생
            if (audioSource != null)
            {
                if (currentJumpCount == 1 && firstJumpSound != null)
                {
                    audioSource.PlayOneShot(firstJumpSound);
                }
                else if (currentJumpCount == 2 && doubleJumpSound != null)
                {
                    audioSource.PlayOneShot(doubleJumpSound);
                }
            }
        }
        // 슬라이딩
        else if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("IsSliding", true);

            // 사운드 1회만 재생
            if (!hasPlayedSlidingSound && slidingSound != null)
            {
                audioSource.PlayOneShot(slidingSound);
                hasPlayedSlidingSound = true;
            }
        }
        else
        {
            animator.SetBool("IsSliding", false);
            hasPlayedSlidingSound = false; // X 키에서 손 떼면 다시 재생 가능하게
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