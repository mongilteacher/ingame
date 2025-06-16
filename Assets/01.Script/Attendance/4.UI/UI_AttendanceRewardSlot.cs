using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_AttendanceRewardSlot : MonoBehaviour
{
    private AttendanceRewardDTO _dto;

    public Image RewardTypeIcon;
    public TextMeshProUGUI RewardAmountTextUI;
    public Button RewardClaimButton;
    
    public void Refresh(AttendanceRewardDTO attendanceReward)
    {
        _dto = attendanceReward;

        RewardAmountTextUI.text = $"{_dto.Amount:N0}개";
        RewardClaimButton.enabled = _dto.CanClaim;
    }

    // 
    public void TryRewardClaim()
    {
      //  AttendanceManager.Instance.TryRewardClaim("출석 ID", "출석 보상 인덱스");
    }
}