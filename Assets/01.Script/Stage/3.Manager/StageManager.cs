using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    // 도메인에 변화가 있을 때 호출되는 액션
    public event Action OnDataChanged;
    
    [SerializeField] 
    private List<StageLevel> _levelSOList;
    public Stage _stage;
    
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
        _stage = new Stage(0, 17, _levelSOList);
    }
}
