using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// 군 전체 정보
public class DomainArmy : MonoBehaviour
{
    // 전략 세팅 시스템
    StrategySettingSystem strategySettingSystem = new StrategySettingSystem();

    TempDomainData tempDomainData;//임시로 영지 데이터 가져오기

    // 군 정보 리스트
    // 기사리스트
    List<Knight> knightList = new List<Knight>();
    // 병종리스트
    List<UnitType> unitTypeList = new List<UnitType>();
    // 전략리스트
    List<Strategy> strategyList = new List<Strategy>();
    // 부대임무리스트
    List<UnitDivisionRoleDataTable> unitDivisionRoleDataList = new List<UnitDivisionRoleDataTable>();

    public List<Knight> KnightList
    {
        get { return knightList; }
        private set { knightList = value; }
    }
    public List<UnitType> UnitTypeList
    {
        get { return unitTypeList; }
        private set { unitTypeList = value; }
    }
    public List<Strategy> StrategyList {
        get { return strategyList; } 
        set { strategyList = value; }
    }
    public List<UnitDivisionRoleDataTable> UnitDivisionRoleDataList
    {
        get { return unitDivisionRoleDataList; }
        set {  unitDivisionRoleDataList = value; }
    }
    private void Awake()
    {

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
            Debug.LogError("데이터 로드 실패!");
        }
        LogDomainArmyData();
    }

    public void TempSetData()
    {
        TempSetKnightList();
        TempSetUnitTypeList();
        TempSetStrategyList();
        TempSetUnitDivisionRoleDataList();
    }
    public void TempSetKnightList()
    {
        if (tempDomainData.knightDataArray == null || tempDomainData.knightDataArray.KnightDataTable == null)
        {
            Debug.LogError("knightDataArray or KnightDataTable is null!");
            return;
        }
        List<KnightDataTable> KnightDataTable = tempDomainData.knightDataArray.KnightDataTable;
        for (int i = 0; i < KnightDataTable.Count; i++)
        {
            GameObject knightObj = new GameObject($"Knight_{KnightDataTable[i].ID}");
            Knight knight = knightObj.AddComponent<Knight>();
            knight.SetKnightData(KnightDataTable[i]);
            knightList.Add(knight);
        }

    }
    public void TempSetUnitTypeList()
    {
        if (tempDomainData.unitTypeDataArray == null || tempDomainData.unitTypeDataArray.UnitTypeDataTable == null)
        {
            Debug.LogError("unitTypeDataArray or UnitTypeDataTable is null!");
            return;
        }
        List<UnitTypeDataTable> unitTypeDataTable = tempDomainData.unitTypeDataArray.UnitTypeDataTable;
        for (int i = 0; i < unitTypeDataTable.Count; i++)
        {
            GameObject unitTypeObj = new GameObject($"UnitType_{unitTypeDataTable[i].ID}");
            UnitType unitType = unitTypeObj.AddComponent<UnitType>();
            unitType.SetUnitTypeData(unitTypeDataTable[i]);
            unitTypeList.Add(unitType);
        }
    }
    public void TempSetStrategyList()
    {
        if (tempDomainData.strategyDataArray == null || tempDomainData.strategyDataArray.StrategyDataTable == null)
        {
            Debug.LogError("strategyDataArray or StrategyDataTable is null!");
            return;
        }
        List<StrategyDataTable> strategyDataTable = tempDomainData.strategyDataArray.StrategyDataTable;
        for (int i = 0; i < strategyDataTable.Count; i++)
        {
            GameObject strategyObj = new GameObject($"Strategy_{strategyDataTable[i].ID}");
            Strategy strategy = strategyObj.AddComponent<Strategy>();
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
        List<UnitDivisionRoleDataTable> unitDivisionRoleDataTable = tempDomainData.unitDivisionRoleDataArray.UnitDivisionRoleDataTable;
        for (int i = 0; i < unitDivisionRoleDataTable.Count; i++)
        {
            GameObject roleObj = new GameObject($"UnitDivisionRole_{unitDivisionRoleDataTable[i].ID}");
            UnitDivisionRoleDataTable roleData = unitDivisionRoleDataTable[i];
            unitDivisionRoleDataList.Add(roleData);
        }
    }

    public void LogDomainArmyData()
    {
        LogKnightData();
        LogUnitTypeData();
        LogStrategyData();
        LogUnitDivisionRoleData();
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

}
// 전략 설정 시스템
public class StrategySettingSystem : MonoBehaviour
{
    DomainArmy domainArmy;
    // 전략리스트 
    List<Strategy> strategyList;
    // 부대임무리스트
    List<UnitDivisionRoleDataTable> unitDivisionRoleDataList;

    Strategy currentStrategy;

    private void Start()
    {
        strategyList = domainArmy.StrategyList;
        unitDivisionRoleDataList = domainArmy.UnitDivisionRoleDataList;
    }
    // UI의 반응과 연계하여 전략 설정 및 저장
}
// 기사
public class Knight : MonoBehaviour
{
    // 기사 정보
    KnightDataTable knightData;

    public KnightDataTable KnightData
    {
        get { return knightData; }
        private set { knightData = value; }
    }

    public void SetKnightData(KnightDataTable inputKnightData)
    {
        knightData = inputKnightData;
    }
}
// 병종
public class UnitType : MonoBehaviour
{
    // 병종 정보
    UnitTypeDataTable unitTypeData;

    public UnitTypeDataTable UnitTypeData
    {
        get { return unitTypeData; }
        private set { unitTypeData = value; }
    }
    public void SetUnitTypeData(UnitTypeDataTable inputUnitTypeData)
    {
        unitTypeData = inputUnitTypeData;
    }
}
// 전략
public class Strategy : MonoBehaviour
{
    // 전략 정보
    StrategyDataTable strategyData;

    public StrategyDataTable StrategyData
    {
        get { return strategyData; }
        private set { strategyData = value; }
    }

    public void SetStrategyData(StrategyDataTable inputStrategyData)
    {
        strategyData = inputStrategyData;
    }
}
// 부대
public class UnitDivision : MonoBehaviour
{
    // 부대 정보
    UnitDivisionDataTable unitDivisionData;

    public UnitDivisionDataTable UnitDivisionData
    {
        get { return unitDivisionData; }
        private set { unitDivisionData = value; }
    }

    public void SetUnitDivisionData(UnitDivisionDataTable inputUnitDivisionData)
    {
        unitDivisionData = inputUnitDivisionData;
    }
}
// 부대 배치
public class UnitDivisionPosition : MonoBehaviour
{
    // 부대배치정보 - 부대(UnitDivision), 위치(Position), 회전(Rotation)
    UnitDivisionPositionDataTable unitDivisionPositionData;

    public UnitDivisionPositionDataTable UnitDivisionPositionData
    {
        get { return unitDivisionPositionData; }
        private set { unitDivisionPositionData = value; }
    }

    public void SetUnitDivisionPositionData(UnitDivisionPositionDataTable inputUnitDivisionPositionData)
    {
        unitDivisionPositionData = inputUnitDivisionPositionData;
    }

    //UnitDivision unitDivision;
    //Vector3 position;
    //Vector3 rotation;
    // 부대의 병종과 수, 위치, 방향에 맞게 병사와 기사를 필드에 생성해주는 로직
}

// 병사
public class Soldier : MonoBehaviour
{
    // 부대의 UnitType의 데이터를 참조해서, 병사들이 전투중에 행동하는 로직에 사용
    UnitDivisionDataTable unitDivisionData;

    public UnitDivisionDataTable UnitDivisionData
    {
        get { return unitDivisionData; }
        private set { unitDivisionData = value; }
    }
    
    public void SetSoldierData(UnitDivisionDataTable inputUnitDivisionData)
    {
        unitDivisionData = inputUnitDivisionData;
    }
}