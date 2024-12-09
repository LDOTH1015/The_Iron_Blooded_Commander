using System;
using System.Collections.Generic;

// 일단 아직은 DomainArmy에서만 쓰임
[Serializable]
public class LordDataTable : IData
{
    public int ID { get; set; }
    public string NameEn { get; set; }
    public string NameKr { get; set; }
    public string Description { get; set; }
    public string Prefeb { get; set; }
    public string Thumbnail { get; set; }
    public float AttackPower { get; set; }
    public float AttackSpeed { get; set; }
    public float Health { get; set; }
    public float Defense { get; set; }
    public float MoveSpeed { get; set; }
    public float AttackRange { get; set; }
    public int Leadership { get; set; }
    public int Intelligence { get; set; }
    public int TrainingLevel { get; set; }
    public int Experience { get; set; }
    public float TrainingWeighted { get; set; }
    public float ExperienceWeighted { get; set; }
}

public class LordDataArray
{
    public List<LordDataTable> LordDataTable;
}