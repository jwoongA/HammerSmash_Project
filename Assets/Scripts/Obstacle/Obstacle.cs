using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleType
{
    Overhead,      // 상단 장애물 (슬라이딩으로 피하기)
    Ground,        // 하단 장애물 (점프해서 피하기)
    FallHole,      // 떨어지는 구멍 장애물 (점프해서 피하기)
    Destructible   // 망치로 부술 수 있는 장애물
}

namespace runner
{
    public class Obstacle : MonoBehaviour
    {
        [Header("장애물 종류")]
        public ObstacleType obstacleType;

        [Header("장애물 속성 조절")]
        [SerializeField] private float minHeight = 1f; //장애물 최소 높이
        [SerializeField] private float maxHeight = 3f; //장애물 최대 높이
        [SerializeField] private float minWidth = 1f; //장애물 최소 너비
        [SerializeField] private float maxWidth = 3f; //장애물 최대 너비

        [Tooltip("장애물 간 간격 범위")]
        [SerializeField] private float minSpacing = 2f; //장애물 최소 간격
        [SerializeField] private float maxSpacing = 10f; //장애물 최대 간격

        [Header("고정 위치 설정")]
        [SerializeField] private Vector3[] fixedPositions;

        [Header("피격 관련 설정")]
        [SerializeField] private float damage = 10f;

        private int spawnIndex = 0; //장애물 고정위치 인덱스

        void Start()
        {
            //시작할 때 장애물 위치와 크기를 설정
            SetupObstacleShape();
        }

        void Update()
        {
            //장애물 이동 속도 (플레이어에게 다가오는 느낌)
            transform.Translate(Vector3.left * Time.deltaTime * 5f);

            //화면 밖으로 나가면 삭제
            if (transform.position.x < -20f)
                Destroy(gameObject);
        }

        private void SetupObstacleShape()
        {
            // 고정 위치에서 현재 장애물의 위치를 설정
            if (spawnIndex < fixedPositions.Length)
                transform.position = fixedPositions[spawnIndex];

            // 장애물 종류에 따라 위치/크기 다르게 설정
            switch (obstacleType)
            {
                case ObstacleType.Overhead:
                    // 화면 위쪽에 고정된 높이로 배치
                    transform.position = new Vector3(transform.position.x, 3f, 0);
                    transform.localScale = new Vector3(1, Random.Range(minHeight, maxHeight), 1);
                    break;

                case ObstacleType.Ground:
                    // 바닥에 붙어 있는 장애물
                    transform.position = new Vector3(transform.position.x, 0f, 0);
                    transform.localScale = new Vector3(1, Random.Range(minHeight, maxHeight), 1);
                    break;

                case ObstacleType.FallHole:
                    // 땅이 없는 구간 (너비만 조절)
                    transform.position = new Vector3(transform.position.x, 0f, 0);
                    float holeWidth = Random.Range(minWidth, maxWidth);
                    transform.localScale = new Vector3(holeWidth, 1, 1);
                    break;

                case ObstacleType.Destructible:
                    // 기본 높이로 배치, 플레이어가 부수는 대상
                    transform.position = new Vector3(transform.position.x, 0f, 0);
                    transform.localScale = new Vector3(1, 1, 1);
                    break;
            }
        }

    }
}
