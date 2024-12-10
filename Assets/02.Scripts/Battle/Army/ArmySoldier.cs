using UnityEngine;
// 병사
public class ArmySoldier : MonoBehaviour
{
    // 부대의 UnitType의 데이터를 참조해서, 병사들이 전투중에 행동하는 로직에 사용
    UnitDivision unitDivisionData;

    public UnitDivision UnitDivisionData
    {
        get { return unitDivisionData; }
        private set { unitDivisionData = value; }
    }
    
    public void SetSoldierData(UnitDivision inputUnitDivisionData)
    {
        unitDivisionData = inputUnitDivisionData;
    }
}