using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;
    
    
    [SerializeField]
    private List<AchievementSO> _metaDatas;
    
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

        _achievements = new List<Achievement>();

        foreach (var metaData in _metaDatas)
        {
            Achievement achievement = new Achievement(metaData);
            _achievements.Add(achievement);
        }
    }
}
