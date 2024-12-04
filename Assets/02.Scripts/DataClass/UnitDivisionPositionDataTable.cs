using System;
using System.Collections.Generic;

[Serializable]
public class UnitDivisionPositionDataTable : IData
{
    public int ID { get; set; }
    public string UnitDivisionID { get; set; }
    public int[] Position { get; set; }
    public int[] Rotation { get; set; }
}

public class UnitDivisionPositionDataaArray
{
    public List<UnitDivisionPositionDataTable> UnitDivisionPositionDataTable;
}

public class UnitDivisionPositionInfo : AutoSave<UnitDivisionPositionDataaArray>
{
    public UnitDivisionPositionInfo() : base("UnitDivisionPositionDataTable") { }
}