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

    private PlayerStatus playerStatus;

    public AudioClip firstJumpSound; // 1�� ���� �Ҹ�
    public AudioClip doubleJumpSound; // 2�� ���� �Ҹ�
    private AudioSource audioSource;

    public AudioClip slidingSound; // �����̵� �Ҹ�
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
        // ����
        if (Input.GetKeyDown(KeyCode.Z) && currentJumpCount < maxJumpCount)
        {
            Playerrigidbody.velocity = new Vector2(Playerrigidbody.velocity.x, jumpForce);
            animator.SetBool("IsJump", true);
            animator.SetBool("IsSliding", false);

            currentJumpCount++;

            // ���� Ƚ���� ���� �ٸ� �Ҹ� ���
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
        // �����̵�
        else if (Input.GetKey(KeyCode.X) && currentJumpCount == 0)
        {
            animator.SetBool("IsSliding", true); // �����̵� �ִϸ��̼� ���

            if (!hasPlayedSlidingSound && slidingSound != null) // �����̵� �Ҹ� �߰�
            {
                audioSource.PlayOneShot(slidingSound);
                hasPlayedSlidingSound = true;
            }
        }
        else
        {
            animator.SetBool("IsSliding", false);
            hasPlayedSlidingSound = false; // �����̵� ��ҽ� ���� �ʱ�ȭ
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