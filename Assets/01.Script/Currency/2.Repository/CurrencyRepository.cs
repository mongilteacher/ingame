using System.Collections.Generic;
using UnityEngine;

public class CurrencyRepository
{
    // Repository: 데이터의 영속성 보장
    // 영속성: 프로그램을 종료해도 데이터가 보존되는 것
    
    private const string SAVE_KEY = nameof(CurrencyRepository);
    
    // Save
    public void Save(List<CurrencyDTO> dataList)
    {
        CurrencySaveData data = new CurrencySaveData();
        data.DataList = dataList;

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }
   
    // Load
    public List<CurrencyDTO> Load()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY))
        {
            return null;
        }
        
        string json = PlayerPrefs.GetString(SAVE_KEY);
        CurrencySaveData data = JsonUtility.FromJson<CurrencySaveData>(json);
        
        return data.DataList;
    }
}

public class CurrencySaveData
{
    public List<CurrencyDTO> DataList;
}