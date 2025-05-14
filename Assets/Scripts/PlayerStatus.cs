using runner;
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
    private PlayerEffect effect;

    public AudioClip hitSound;
    private AudioSource audioSource;

    public GameObject gameOverPanel; //사망시 출력할 판넬
    public bool isFallen = false; // 추락 관련 코드, 중복 호출 방지용
    private StageManager stageManager;
    private ObstacleSpawner obstacleSpawner;
    private RoadSpawner roadSpawner;
    public GameSpeedManager gameSpeedManager;


    void Start()
    {
        currentHP = maxHP;                 
        animator = GetComponentInChildren<Animator>(); 
        effect = GetComponent<PlayerEffect>();

        if (gameOverPanel != null) 
            gameOverPanel?.SetActive(false); // 게임 오버 판넬 혹시 모르니 실행 시 비활성화 확실히 해두기
        
        stageManager = FindObjectOfType<StageManager>();
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        roadSpawner = FindObjectOfType<RoadSpawner>();
        gameSpeedManager = FindObjectOfType<GameSpeedManager>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

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
        //추락 확인 코드
        {
            // 화면 아래로 떨어졌는지 검사
            if (!isFallen && transform.position.y < -10f)
            {
                isFallen = true;
                Debug.Log(" 플레이어가 화면 밖으로 떨어짐 → 게임 오버 처리");

                Die();
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (effect != null && effect.isInvincible) return; // 아이템 효과로 무적 중이면 무시
        if (isTakingDamage) return; // 무적 상태면 무시

        currentHP -= damage;        // 체력 감소
        isTakingDamage = true;      // 무적 상태로 설정

        if (animator != null)
            animator.SetBool("IsDamage", true);

        Invoke("EndDamage", 0.5f); // 무적시간 0.5초

        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(20f); // 최대 5번 충돌 시 사망
        }
        if (other.CompareTag("Obstacle"))
        {
            // 무적 중엔 충돌해도 TakeDamage 안 불러줌
            if (effect != null && effect.isInvincible) return;
            TakeDamage(20f);
        }
        
    }

    private bool isDead = false;
    void Die()
    {
        if (isDead) return; // 사망 처리는 단 1회만
        isDead = true;
        Debug.Log("사망! 게임 오버 UI 출력");
        Time.timeScale = 0f;

        // 점수와 시간 저장
        var effect = GetComponent<PlayerEffect>();
        var timer = FindObjectOfType<GameTimer>();

        if (effect != null && timer != null)
        {
            ScoreDataBuffer.FinalScore = effect.score;
            ScoreDataBuffer.FinalTime = timer.GetElapsedTime();

            ScoreManager.TrySetNewHighScore(effect.score);
            ScoreManager.TrySetNewBestTime(timer.GetElapsedTime());
        }

        //맵생성 중지
       // gameSpeedManager.enabled = false;


        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            // 명시적으로 점수 반영!
            var display = gameOverPanel.GetComponent<GameOverScoreDisplay>();
            if (display != null)
            {
                display.ShowScore();
            }
        }
    }
}


