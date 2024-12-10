using System.Collections.Generic;
using System.Text;
using UnityEngine;
// 전략 설정 시스템
public class StrategySettingSystem : MonoBehaviour
{
    DomainArmy domainArmy;
    // 전략리스트 
    List<ArmyStrategy> strategyList;
    // 부대임무리스트
    List<UnitDivisionRole> unitDivisionRoleDataList;
    // 영주
    ArmyLord domainArmyLord;
    // 기사리스트
    List<ArmyKnight> knightList;
    // 병종리스트
    List<ArmyUnitType> unitTypeList;

    Strategy currentStrategy;

    private void Awake()
    {
        if (TryGetComponent<DomainArmy>(out domainArmy))
        {
            Debug.Log($"영지 -> 전략설정 {typeof(DomainArmy).Name} 로드 성공!");
        }
        else
        {
            Debug.LogError($"영지 -> 전략설정 {typeof(DomainArmy).Name} 로드 실패!");
        }
    }

    // DomainArmy의 데이터를 참조
    public void SetStrategySettingSystemData()
    {
        domainArmyLord = domainArmy.DomainArmyLord;
        strategyList = domainArmy.StrategyList;
        unitDivisionRoleDataList = domainArmy.UnitDivisionRoleDataList;
        knightList = domainArmy.KnightList;
        unitTypeList = domainArmy.UnitTypeList;
    }
    // 데이터가 잘 들어갔는지 확인
    public void LogStrategySettingSystemData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("로드: ");
        sb.Append(domainArmyLord.LordData.Name);
        sb.Append("\n");
        sb.Append("전략 시스템's \n전략 목록: ");
        for (int i = 0; i < strategyList.Count; i++)
        {
            sb.Append(strategyList[i].StrategyData.Name);
            sb.Append(", ");
        }
        sb.Append("\n");
        sb.Append("부대 임무 목록: ");
        for (int i = 0; i < unitDivisionRoleDataList.Count; i++)
        {
            sb.Append(unitDivisionRoleDataList[i].Name);
            sb.Append(", ");
        }
        sb.Append("\n");
        sb.Append("기사 목록: ");
        for (int i = 0; i < knightList.Count; i++)
        {
            sb.Append(knightList[i].KnightData.NameKr);
            sb.Append(", ");
        }
        sb.Append("\n");
        sb.Append("병종 목록: ");
        for (int i = 0; i < unitTypeList.Count; i++)
        {
            sb.Append(unitTypeList[i].UnitTypeData.NameKr);
            sb.Append(", ");
        }
        sb.Append("\n");
        Debug.Log(sb);
    }
    // UI의 반응과 연계하여 전략 설정 및 저장

}
