using UnityEngine;
// 기사
public class ArmyKnight : MonoBehaviour
{
    // 기사 정보
    KnightDefault knightData;

    public KnightDefault KnightData
    {
        get { return knightData; }
        private set { knightData = value; }
    }

    public void SetKnightData(KnightDefault inputKnightData)
    {
        knightData = inputKnightData;
    }
}
