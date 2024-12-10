using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// 군 전체 정보
public class DomainArmy : MonoBehaviour
{
    // 전략 세팅 시스템
    StrategySettingSystem strategySettingSystem;

    TempDomainData tempDomainData;//임시로 영지 데이터 가져오기

    // 군 정보 리스트
    // 영주
    ArmyLord domainArmyLord;
    // 기사리스트
    List<ArmyKnight> knightList = new List<ArmyKnight>();
    // 병종리스트
    List<ArmyUnitType> unitTypeList = new List<ArmyUnitType>();
    // 전략리스트
    List<ArmyStrategy> strategyList = new List<ArmyStrategy>();
    // 부대임무리스트
    List<UnitDivisionRole> unitDivisionRoleDataList = new List<UnitDivisionRole>();

    public ArmyLord DomainArmyLord
    {
        get { return domainArmyLord; }
        private set { domainArmyLord = value; }
    }
    public List<ArmyKnight> KnightList
    {
        get { return knightList; }
        private set { knightList = value; }
    }
    public List<ArmyUnitType> UnitTypeList
    {
        get { return unitTypeList; }
        private set { unitTypeList = value; }
    }
    public List<ArmyStrategy> StrategyList {
        get { return strategyList; } 
        set { strategyList = value; }
    }
    public List<UnitDivisionRole> UnitDivisionRoleDataList
    {
        get { return unitDivisionRoleDataList; }
        set { unitDivisionRoleDataList = value; }
    }
    private void Awake()
    {
        if (TryGetComponent<StrategySettingSystem>(out strategySettingSystem))
        {
            Debug.Log($"{typeof(StrategySettingSystem)} 로드 성공!");
        }
        else
        {
            Debug.LogError($"{typeof(StrategySettingSystem)} 로드 실패!");
        }
    }
    private void Start()
    {
        if (TryGetComponent<TempDomainData>(out tempDomainData))
        {
            Debug.Log($"{typeof(TempDomainData)} 로드 성공!");
            TempSetData();
        }
        else
        {
            Debug.LogError($"{typeof(TempDomainData)} 데이터 로드 실패!");
        }
        LogDomainArmyData();
    }

    public void TempSetData()
    {
        TempSetDomainLordData();
        TempSetKnightList();
        TempSetUnitTypeList();
        TempSetStrategyList();
        TempSetUnitDivisionRoleDataList();
        TempSetStrategySettingSystemData();
    }
    public void TempSetDomainLordData()
    {
        if (tempDomainData.lordDataArray == null || tempDomainData.lordDataArray.KnightDefault == null)
        {
            Debug.LogError("lordDataArray or LordDataTable is null!");
            return;
        }
        Lord lordDataTable = tempDomainData.lordDataArray.KnightDefault[0];// 현재 첫 번째 원소가 플레이어로 지정
        GameObject lordObj = new GameObject($"Lord_{lordDataTable.ID}");
        lordObj.transform.SetParent(transform);
        DomainArmyLord = lordObj.AddComponent<ArmyLord>();
        DomainArmyLord.SetLordData(lordDataTable);
    }
    public void TempSetKnightList()
    {
        if (tempDomainData.knightDataArray == null || tempDomainData.knightDataArray.KnightDefault == null)
        {
            Debug.LogError("knightDataArray or KnightDataTable is null!");
            return;
        }
        List<KnightDefault> KnightDataTable = tempDomainData.knightDataArray.KnightDefault;
        for (int i = 0; i < KnightDataTable.Count; i++)
        {
            GameObject knightObj = new GameObject($"Knight_{KnightDataTable[i].ID}");
            knightObj.transform.SetParent(transform);
            ArmyKnight knight = knightObj.AddComponent<ArmyKnight>();
            knight.SetKnightData(KnightDataTable[i]);
            knightList.Add(knight);
        }

    }
    public void TempSetUnitTypeList()
    {
        if (tempDomainData.unitTypeDataArray == null || tempDomainData.unitTypeDataArray.UnitType == null)
        {
            Debug.LogError("unitTypeDataArray or UnitTypeDataTable is null!");
            return;
        }
        List<UnitType> unitTypeDataTable = tempDomainData.unitTypeDataArray.UnitType;
        for (int i = 0; i < unitTypeDataTable.Count; i++)
        {
            GameObject unitTypeObj = new GameObject($"UnitType_{unitTypeDataTable[i].ID}");
            unitTypeObj.transform.SetParent(transform);
            ArmyUnitType unitType = unitTypeObj.AddComponent<ArmyUnitType>();
            unitType.SetUnitTypeData(unitTypeDataTable[i]);
            unitTypeList.Add(unitType);
        }
    }
    public void TempSetStrategyList()
    {
        if (tempDomainData.strategyDataArray == null || tempDomainData.strategyDataArray.Strategy == null)
        {
            Debug.LogError("strategyDataArray or StrategyDataTable is null!");
            return;
        }
        List<Strategy> strategyDataTable = tempDomainData.strategyDataArray.Strategy;
        for (int i = 0; i < strategyDataTable.Count; i++)
        {
            GameObject strategyObj = new GameObject($"Strategy_{strategyDataTable[i].ID}");
            strategyObj.transform.SetParent(transform);
            ArmyStrategy strategy = strategyObj.AddComponent<ArmyStrategy>();
            strategy.SetStrategyData(strategyDataTable[i]);
            strategyList.Add(strategy);
        }
    }
    public void TempSetUnitDivisionRoleDataList()
    {
        if (tempDomainData.unitDivisionRoleDataArray == null || tempDomainData.unitDivisionRoleDataArray.UnitDivisionRoleDataTable == null)
        {
            Debug.LogError("unitDivisionRoleDataArray or UnitDivisionRoleDataTable is null!");
            return;
        }
        List<UnitDivisionRole> unitDivisionRoleDataTable = tempDomainData.unitDivisionRoleDataArray.UnitDivisionRoleDataTable;
        for (int i = 0; i < unitDivisionRoleDataTable.Count; i++)
        {
            GameObject roleObj = new GameObject($"UnitDivisionRole_{unitDivisionRoleDataTable[i].ID}");
            roleObj.transform.SetParent(transform);
            UnitDivisionRole roleData = unitDivisionRoleDataTable[i];
            unitDivisionRoleDataList.Add(roleData);
        }
    }
    public void TempSetStrategySettingSystemData()
    {
        strategySettingSystem.SetStrategySettingSystemData();
    }
    
    public void LogDomainArmyData()
    {
        LogDomainLordData();
        LogKnightData();
        LogUnitTypeData();
        LogStrategyData();
        LogUnitDivisionRoleData();
        LogStrategySettingSystemData();
    }
    public void LogDomainLordData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("로드: ");
        sb.Append(DomainArmyLord.LordData.Name);
        sb.Append("\n");
        Debug.Log(sb);
    }
    public void LogKnightData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("기사 목록: ");
        for (int i = 0; i < KnightList.Count; i++)
        {
            sb.Append(KnightList[i].KnightData.NameKr);
            sb.Append(", ");
        }
        sb.Append("\n");
        Debug.Log(sb);
    }
    public void LogUnitTypeData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("병종 목록: ");
        for (int i = 0; i < UnitTypeList.Count; i++)
        {
            sb.Append(UnitTypeList[i].UnitTypeData.NameKr);
            sb.Append(", ");
        }
        sb.Append("\n");
        Debug.Log(sb);
    }
    public void LogStrategyData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("전략 목록: ");
        for (int i = 0; i < StrategyList.Count; i++)
        {
            sb.Append(StrategyList[i].StrategyData.Name);
            sb.Append(", ");
        }
        sb.Append("\n");
        Debug.Log(sb);
    }
    public void LogUnitDivisionRoleData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("부대 임무 목록: ");
        for (int i = 0; i < UnitDivisionRoleDataList.Count; i++)
        {
            sb.Append(UnitDivisionRoleDataList[i].Name);
            sb.Append(", ");
        }
        sb.Append("\n");
        Debug.Log(sb);
    }
    public void LogStrategySettingSystemData()
    {
        strategySettingSystem.LogStrategySettingSystemData();
    }

}
