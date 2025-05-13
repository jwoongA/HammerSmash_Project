using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    Overhead,    // ��� ��ֹ� (�����̵�)
    Ground,      // �ϴ� ��ֹ� (����)
    FallHole     // �������� ����
}

namespace runner
{
    public class Obstacle : MonoBehaviour
    {
        [Header("��ֹ� ����")]
        public ObstacleType obstacleType;

        [Tooltip("��ֹ� �� ���� ����")]
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
