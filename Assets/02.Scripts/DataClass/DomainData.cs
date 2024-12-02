using System;

[Serializable]
public class DomainData
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string LordID { get; set; }
    public int Population { get; set; }
    public int PublicOpinion { get; set; }
    public int Fame { get; set; }
    public int Gold { get; set; }
    public int Steel { get; set; }
    public int Food { get; set; }
    public int Captivity { get; set; }
    public int MarketLevel { get; set; }
    public int MineLevel { get; set; }
    public int FarmlandLevel { get; set; }
    public int RampartLevel { get; set; }
    public float Tariff { get; set; }
}

[Serializable]
public class DomainInfo : AutoSave<DomainData>
{
    public DomainInfo() : base("DomainData") { }
}