using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    private List<Achievement> _achievements;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        // 초기화
        
        _achievements = new List<Achievement>
        {
            new Achievement(
                id: "ACH_MONEY_001",
                name: "첫 수익",
                description: "100 골드 획득",
                condition: EAchievementCondition.GoldCollect,
                goalValue: 100,
                rewardCurrencyType: ECurrencyType.Gold,
                rewardAmount: 300
            ),
    
            new Achievement(
                id: "ACH_MONEY_002",
                name: "부자 되기 1단계",
                description: "총 1000 골드 획득",
                condition: EAchievementCondition.GoldCollect,
                goalValue: 1000,
                rewardCurrencyType: ECurrencyType.Diamond,
                rewardAmount: 1
            ),

            new Achievement(
                id: "ACH_KILL_DRONE_001",
                name: "드론 헌터",
                description: "드론 타입 몬스터 10마리 처치",
                condition: EAchievementCondition.DronKillCount,
                goalValue: 10,
                rewardCurrencyType: ECurrencyType.Gold,
                rewardAmount: 1000
            ),

            new Achievement(
                id: "ACH_KILL_DRONE_002",
                name: "드론 학살자",
                description: "드론 타입 몬스터 50마리 처치",
                condition: EAchievementCondition.DronKillCount,
                goalValue: 100,
                rewardCurrencyType: ECurrencyType.Diamond,
                rewardAmount: 2
            ),

            new Achievement(
                id: "ACH_KILL_BOSS_001",
                name: "보스 저격수",
                description: "보스 몬스터 1기 격추",
                condition: EAchievementCondition.BossKillCount,
                goalValue: 1,
                rewardCurrencyType: ECurrencyType.Diamond,
                rewardAmount: 3
            ),

            new Achievement(
                id: "ACH_TIME_001",
                name: "진득하게",
                description: "플레이 누적 시간 10분 달성",
                condition: EAchievementCondition.PlayTime,
                goalValue: 600, // 초 단위라 가정
                rewardCurrencyType: ECurrencyType.Diamond,
                rewardAmount: 5
            ),

            new Achievement(
                id: "ACH_HIDDEN_001",
                name: "눈썰미",
                description: "특정 위치의 숨겨진 장소",
                condition: EAchievementCondition.Trigger,
                goalValue: 777,
                rewardCurrencyType: ECurrencyType.Diamond,
                rewardAmount: 10
            ),
        };
    }
}
