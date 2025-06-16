using System.Collections.Generic;
using UnityEngine;

public class UI_Attendance : MonoBehaviour
{
    public List<UI_AttendanceRewardSlot> Slots;


    private void Start()
    {
        Refresh();

        AttendanceManager.Instance.OnDataChanged += Refresh;
    }
    
    private void Refresh()
    {
        AttendanceDTO attendance = AttendanceManager.Instance.GetAttendance(0);

        foreach (var slot in Slots)
        {
            slot.Refresh(attendance.Rewards[0]);
        }
    }
}