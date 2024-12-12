using UnityEngine;
// 병종
public class ArmyUnitType : MonoBehaviour
{
    // 병종 정보
    UnitType unitTypeData;

    public UnitType UnitTypeData
    {
        get { return unitTypeData; }
        private set { unitTypeData = value; }
    }
    public void SetUnitTypeData(UnitType inputUnitTypeData)
    {
        unitTypeData = inputUnitTypeData;
    }
}
