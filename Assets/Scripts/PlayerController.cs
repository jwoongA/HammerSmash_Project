using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    private Rigidbody2D Playerrigidbody;
    private Animator animator;

    public int maxJumpCount = 2;
    private int currentJumpCount = 0;

    private PlayerStatus playerStatus;

    public AudioClip firstJumpSound;
    public AudioClip doubleJumpSound;
    public AudioClip slidingSound;

    private AudioSource audioSource;
    private bool hasPlayedSlidingSound = false;

    private float horizontalInput;

    void Start()
    {
        Playerrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        playerStatus = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // 점프
        if (Input.GetKeyDown(KeyCode.Z) && currentJumpCount < maxJumpCount)
        {
            Playerrigidbody.velocity = new Vector2(Playerrigidbody.velocity.x, jumpForce);
            animator.SetBool("IsJump", true);
            animator.SetBool("IsSliding", false);

            currentJumpCount++;

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
        else if (Input.GetKey(KeyCode.X) && currentJumpCount == 0)
        {
            animator.SetBool("IsSliding", true);

            if (!hasPlayedSlidingSound && slidingSound != null)
            {
                audioSource.PlayOneShot(slidingSound);
                hasPlayedSlidingSound = true;
            }
        }
        else
        {
            animator.SetBool("IsSliding", false);
            hasPlayedSlidingSound = false;
        }
    }
    void FixedUpdate()
    {

        Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, Playerrigidbody.velocity.y);
        Playerrigidbody.velocity = newVelocity;
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


    public GameObject gameClearUI; // 인스펙터에서 연결

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            Time.timeScale = 0f; // 일시 정지 (선택사항)
            gameClearUI.SetActive(true); // 게임 클리어 UI 띄움
        }
    }
}