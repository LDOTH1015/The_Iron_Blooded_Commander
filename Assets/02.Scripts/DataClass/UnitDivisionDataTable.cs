using System;

[Serializable]
public class UnitDivisionDataTable
{
    public int ID { get; set; }
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

[Serializable]
public class UnitDivisionInfo
{
    public UnitDivisionDataTable[] UnitDivisionDatas;
}