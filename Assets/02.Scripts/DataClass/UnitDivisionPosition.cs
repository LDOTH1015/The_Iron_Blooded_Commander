using System;
using System.Collections.Generic;

[Serializable]
public class UnitDivisionPosition : IData
{
    public string ID { get; set; }
    public string StrategyID { get; set; }
    public string UnitDivisionID { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int PositionZ { get; set; }
    public int RotationX { get; set; }
    public int RotationY { get; set; }
    public int RotationZ { get; set; }
}

public class UnitDivisionPositionDataaArray
{
    public List<UnitDivisionPosition> UnitDivisionPositionDataTable;
}

public class UnitDivisionPositionInfo : AutoSave<UnitDivisionPositionDataaArray>
{
    public UnitDivisionPositionInfo() : base("UnitDivisionPositionDataTable") { }
}