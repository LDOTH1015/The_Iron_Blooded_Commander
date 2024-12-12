using System;
using System.Collections.Generic;

[Serializable]
public class UnitDivision : IData
{
    public string ID { get; set; }
    public string DomainID { get; set; }
    public string StrategyID { get; set; }
    public string NameEn { get; set; }
    public string NameKr { get; set; }
    public string Description { get; set; }
    public bool IsKnightAlive { get; set; }
    public int KnightID { get; set; }
    public int UnitDivisionRole { get; set; }
    public int UnitTypeID { get; set; }
    public int UnitPersonnel { get; set; }
    public float Morale { get; set; }
}

public class UnitDivisionDataArray
{
    public List<UnitDivision> UnitDivision;
}

public class UnitDivisionInfo : AutoSave<UnitDivisionDataArray>
{
    public UnitDivisionInfo() : base("UnitDivision") { }
}