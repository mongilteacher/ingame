using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendanceManager : MonoBehaviour
{
    public static AttendanceManager Instance;

    [SerializeField]
    private List<AttendanceSO> _attendanceSoList;

    private List<Attendance> _attendances;
    
    
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
        _attendances = new List<Attendance>(_attendanceSoList.Count);
        DateTime today = DateTime.Today;
        
        // SO를 순회하면서
        foreach (var atttendanceSo in _attendanceSoList)
        {
            // 아직 시작한 이벤트가 아니라면 건너뛴다.
            if (atttendanceSo.StartDate < today)
            {
                continue;
            }

            Attendance attendance = new Attendance(atttendanceSo.ID, atttendanceSo.StartDate, today, 1);
            foreach (var atendanceRewardSO in atttendanceSo.AttendanceRewards)
            {
                attendance.AddReward(new AttendanceReward(atendanceRewardSO.CurrencyType, atendanceRewardSO.Amount, false));
            }
            
            _attendances.Add(attendance);
        }
        
        StartCoroutine(Check_Coroutine());
    }

    public AttendanceDTO GetAttendance(int index)
    {
        if (index < 0 || _attendances.Count <= index)
        {
            throw new ArgumentOutOfRangeException("출석 이벤트 인덱스가 범위를 벗어납니다.");
        }

        return _attendances[index].ToDTO();
    }
    

    private IEnumerator Check_Coroutine()
    {
        var hourTimeWait = new WaitForSecondsRealtime(60 * 60);

        while (true)
        {
            DateTime today = DateTime.Today;

            foreach (Attendance attendance in _attendances)
            {
                // 묻지 말고 시켜라!
                attendance.Check(today);

            }
        
            OnDataChanged?.Invoke();

            yield return hourTimeWait;
        }
    }
    
}
