using System;
using System.Collections.Generic;

[Serializable]
public class KnightDataTable
{
    public int ID { get; set; }
    public string NameEn { get; set; }
    public string NameKr { get; set; }
    public string Description { get; set; }
    public int Rank { get; set; }
    public string Prefeb { get; set; }
    public string Image { get; set; }
    public float AttackPower { get; set; }
    public float AttackSpeed { get; set; }
    public float Health { get; set; }
    public float Defense { get; set; }
    public float MoveSpeed { get; set; }
    public float AttackRange { get; set; }
    public int Leadership { get; set; }
    public int Intelligence { get; set; } 
    public int Loyalty { get; set; }
    public int DownPayment { get; set; }
    public int Salary { get; set; }
    public int TrainingLevel { get; set; }
    public int Experience { get; set; }
    public float TrainingWeighted { get; set; }
    public float ExperienceWeighted { get; set; }
}

public class KnightDataArray
{
    public List<KnightDataTable> KnightDataTable;
}

public class KnightInfo : AutoSave<KnightDataArray>
{
    public KnightInfo() : base("KnightDataTable") { }
}