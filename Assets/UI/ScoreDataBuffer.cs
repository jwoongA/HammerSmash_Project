using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreDataBuffer
{
    // 게임이 끝났을 때 기록용
    public static int FinalScore;
    public static float FinalTime;

    // 씬 이동 중 유지용
    public static int CurrentScore;     
    public static float CurrentTime;
} // 스코어를 기록