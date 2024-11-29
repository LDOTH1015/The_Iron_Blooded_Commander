using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IManager
{
    public KnightInfo knightInfo;
    public UnitTypeInfo unitTypeInfo;
    public UnitDivisionInfo unitDivisionnfo;

    public void Initialize()
    {
        var KnightJson= Resources.Load("JsonData/KnightData") as TextAsset;
        var UnitTypeJson = Resources.Load("JsonData/UnitTypeData") as TextAsset;
        var UnitDivisionJson = Resources.Load("JsonData/UnitDivisionData") as TextAsset;
        knightInfo = JsonUtility.FromJson<KnightInfo>(KnightJson.ToString());
        unitTypeInfo = JsonUtility.FromJson<UnitTypeInfo>(UnitTypeJson.ToString());
        unitDivisionnfo = JsonUtility.FromJson<UnitDivisionInfo>(UnitDivisionJson.ToString());
    }
}
