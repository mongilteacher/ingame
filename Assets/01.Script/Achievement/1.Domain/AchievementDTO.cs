using System;

public class AchievementDTO
{
    public readonly string ID;
    public readonly string Name;
    public readonly string Description;
    public readonly EAchievementCondition Condition;
    public readonly int GoalValue;
    public readonly int CurrentValue;
    public readonly bool RewardClaimed;
    public readonly ECurrencyType RewardCurrencyType;
    public readonly int RewardAmount;

    public AchievementDTO(
        string id,
        string name,
        string description,
        EAchievementCondition condition,
        int goalValue,
        int currentValue,
        bool rewardClaimed,
        ECurrencyType rewardCurrencyType,
        int rewardAmount)
    {
        ID = id;
        Name = name;
        Description = description;
        Condition = condition;
        GoalValue = goalValue;
        CurrentValue = currentValue;
        RewardClaimed = rewardClaimed;
        RewardCurrencyType = rewardCurrencyType;
        RewardAmount = rewardAmount;
    }

    public AchievementDTO(Achievement achievement)
    {
        ID = achievement.ID;
        Name = achievement.Name;
        Description = achievement.Description;
        Condition = achievement.Condition;
        GoalValue = achievement.GoalValue;
        CurrentValue = achievement.CurrentValue;
        RewardClaimed = achievement.RewardClaimed;
        RewardCurrencyType = achievement.RewardCurrencyType;
        RewardAmount = achievement.RewardAmount;
    }
    
    public bool CanClaimReward()
    {
        return RewardClaimed == false && CurrentValue >= GoalValue;
    }
}