using UnityEngine;
// 부대
public class ArmyUnitDivision : MonoBehaviour
{
    // 부대 정보
    UnitDivision unitDivisionData;

    public UnitDivision UnitDivisionData
    {
        get { return unitDivisionData; }
        private set { unitDivisionData = value; }
    }

    public void SetUnitDivisionData(UnitDivision inputUnitDivisionData)
    {
        unitDivisionData = inputUnitDivisionData;
    }
}
