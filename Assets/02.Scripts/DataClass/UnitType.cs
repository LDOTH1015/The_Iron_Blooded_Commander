using System;
using System.Collections.Generic;

[Serializable]
public class UnitType : IData
{
    public string ID { get; set; }
    public string NameEn { get; set; }
    public string NameKr { get; set; }
    public string Description { get; set; }
    public string Prefeb { get; set; }
    public string Thumbnail { get; set; }
    public int UnitTypeCount { get; set; }
    public float AttackPower { get; set; }
    public float AttackSpeed { get; set; }
    public float Health { get; set; }
    public float Defense { get; set; }
    public float MoveSpeed { get; set; }
    public float AttackRange { get; set; }
    public int Salary { get; set; }
    public int TrainingLevel { get; set; }
    public int Experience { get; set; }
    public float TrainingWeighted { get; set; }
    public float ExperienceWeighted { get; set; }
}

public class UnitTypeDataArray
{
    public List<UnitType> UnitType;
}

public class UnitTypeInfo : AutoSave<UnitTypeDataArray>
{
    public UnitTypeInfo() : base("UnitType") { }
}