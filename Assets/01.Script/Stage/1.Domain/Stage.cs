using System;
using System.Collections.Generic;

public class Stage
{
    public int LevelNumber { get; private set; }
    
    private StageLevel _currentLevel;
    private float _progressTime;
    
    public List<StageLevel> Levels { get; private set; } = new List<StageLevel>();


    public Stage(int levelNumber, float progressTime)
    {
        if (levelNumber < 0)
        {
            throw new Exception("올바르지 않은 레벨넘버 입니다.");
        }

        if (progressTime < 0)
        {
            throw new Exception("올바르지 않은 진행 시간입니다.");
        }
        
        
        LevelNumber = LevelNumber;
        _progressTime = progressTime;
    }
    
    public void AddLevel(StageLevel level)
    {
        if (level == null)
        {
            throw new Exception("레벨이 null입니다.");
        }
        
        Levels.Add(level);
    }

    public void Progress(float dt)
    {
        _progressTime += dt;

        if (_currentLevel.TryLevelUp(_progressTime))
        {
            _progressTime = 0;
            
            if (_currentLevel.IsClear())
            {
                LevelNumber += 1;
                _currentLevel = Levels[LevelNumber - 1];
            }
        }
    }
}