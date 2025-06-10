using System.Collections.Generic;
using UnityEngine;

public class AchievementRepository
{
    private const string SAVE_KEY = nameof(AchievementRepository);

    public void Save(List<AchievementDTO> achievements)
    {
        AchievementSaveDataList datas = new AchievementSaveDataList();
        datas.DataList = achievements.ConvertAll(achievement => new AchievementSaveData
        {
            ID = achievement.ID,
            CurrentValue  = achievement.CurrentValue,
            RewardClaimed =  achievement.RewardClaimed,
        });
        
        string json = JsonUtility.ToJson(datas);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    public List<AchievementDTO> Load()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY))
        {
            return null;
        }

        string json = PlayerPrefs.GetString(SAVE_KEY);
        AchievementSaveDataList datas = JsonUtility.FromJson<AchievementSaveDataList >(json);
        
        // DTO로 변환해서 리턴

        return null;
    }
}

[SerializeField]
public struct AchievementSaveData
{
    public string ID;
    public int CurrentValue;
    public bool RewardClaimed;
}

[SerializeField]
public struct AchievementSaveDataList
{
    public List<AchievementSaveData> DataList;
}
