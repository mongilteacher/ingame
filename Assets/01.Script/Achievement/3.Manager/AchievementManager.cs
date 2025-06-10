using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;
    
    
    [SerializeField]
    private List<AchievementSO> _metaDatas;
    
    private List<Achievement> _achievements;
    public List<AchievementDTO> Achievements => _achievements.ConvertAll((a) => new AchievementDTO(a));

    public event Action OnDataChanged;
    
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

        _achievements = new List<Achievement>();
        

        foreach (var metaData in _metaDatas)
        {
            Achievement achievement = new Achievement(metaData);
            _achievements.Add(achievement);
        }
    }

    public void Increase(EAchievementCondition condition, int value)
    {
        foreach (var achievement in _achievements)
        {
            if (achievement.Condition == condition)
            {
                achievement.Increase(value);
            }
        }

        OnDataChanged?.Invoke();
    }
    
    public bool TryClaimReward(AchievementDTO achievementDto)
    {
        Achievement achievement = _achievements.Find(a => a.ID == achievementDto.ID);
        if (achievement == null)
        {
            return false;
        }

        if (achievement.TryClaimReward())
        {
            CurrencyManager.Instance.Add(achievement.RewardCurrencyType, achievement.RewardAmount);
            
            OnDataChanged?.Invoke();
            
            return true;
        }

        return false;
    }
}
