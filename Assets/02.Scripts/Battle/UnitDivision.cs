using UnityEngine;
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
