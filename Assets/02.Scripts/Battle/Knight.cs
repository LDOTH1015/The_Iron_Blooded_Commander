using UnityEngine;
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
