using UnityEngine;
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
