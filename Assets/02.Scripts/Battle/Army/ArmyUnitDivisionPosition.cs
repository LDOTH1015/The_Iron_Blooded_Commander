using UnityEngine;
// 부대 배치
public class ArmyUnitDivisionPosition : MonoBehaviour
{
    // 부대배치정보 - 부대(UnitDivision), 위치(Position), 회전(Rotation)
    UnitDivisionPosition unitDivisionPositionData;

    public UnitDivisionPosition UnitDivisionPositionData
    {
        get { return unitDivisionPositionData; }
        private set { unitDivisionPositionData = value; }
    }

    public void SetUnitDivisionPositionData(UnitDivisionPosition inputUnitDivisionPositionData)
    {
        unitDivisionPositionData = inputUnitDivisionPositionData;
    }

    //UnitDivision unitDivision;
    //Vector3 position;
    //Vector3 rotation;
    // 부대의 병종과 수, 위치, 방향에 맞게 병사와 기사를 필드에 생성해주는 로직
}
