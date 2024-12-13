using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PopupKnightInfo : UIBase
{
    [SerializeField] private TMP_Text txtKnightNameInfo;
    [SerializeField] private TMP_Text txtKnightDescriptionInfo;
    [SerializeField] private Image thumbnailKnight;
    [SerializeField] private TMP_Text txtKnightAtkPowerInfo;
    [SerializeField] private TMP_Text txtKnightAtkSpeedInfo;
    [SerializeField] private TMP_Text txtKnightHealthInfo;
    [SerializeField] private TMP_Text txtKnightDefenseInfo;
    [SerializeField] private TMP_Text txtKnightMoveSpeedInfo;
    [SerializeField] private TMP_Text txtKnightAtkRangeInfo;
    [SerializeField] private TMP_Text txtKnightLeadershipInfo;
    [SerializeField] private TMP_Text txtKnightIntelligenceInfo;
    [SerializeField] private TMP_Text txtKnightLoyaltyInfo;


    public void OnClickBtnBackSpace()
    {
        Hide();
    }

    public void SetKnightInfoData(KnightDefault knightData)
    {
        txtKnightNameInfo.text = knightData.NameKr; 
        txtKnightDescriptionInfo.text = knightData.Description;
        //thumbnailKnight = knightData.Thumbnail;
        txtKnightAtkPowerInfo.text = knightData.AttackPower.ToString();
        txtKnightAtkSpeedInfo.text = knightData.AttackSpeed.ToString();
        txtKnightHealthInfo.text = knightData.Health.ToString();
        txtKnightDefenseInfo.text = knightData.Defense.ToString();
        txtKnightMoveSpeedInfo.text = knightData.MoveSpeed.ToString();
        txtKnightAtkRangeInfo.text = knightData.AttackRange.ToString();
        txtKnightLeadershipInfo.text = knightData.Leadership.ToString();
        txtKnightIntelligenceInfo.text = knightData.Intelligence.ToString();
        txtKnightLoyaltyInfo.text = knightData.Loyalty.ToString();
    }
}
