using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    Overhead,    // 상단 장애물 (슬라이딩)
    Ground,      // 하단 장애물 (점프)
    FallHole     // 떨어지는 구멍
}

namespace runner
{
    public class Obstacle : MonoBehaviour
    {
        [Header("장애물 종류")]
        public ObstacleType obstacleType;

        [Tooltip("장애물 간 간격 범위")]
        [SerializeField] private float minSpacing = 10f;
        [SerializeField] private float maxSpacing = 20f;

        [SerializeField] private int spawnIndex = 0;

        void Awake()
        {
            AutoSetTypeByName();
        }

        public void SetSpawnIndex(int index)
        {
            spawnIndex = index;
        }

        void AutoSetTypeByName()
        {
            string name = gameObject.name.ToLower();

            if (name.Contains("ground")) obstacleType = ObstacleType.Ground;
            else if (name.Contains("overhead")) obstacleType = ObstacleType.Overhead;
            else if (name.Contains("fallhole")) obstacleType = ObstacleType.FallHole;
        }
    }
}
