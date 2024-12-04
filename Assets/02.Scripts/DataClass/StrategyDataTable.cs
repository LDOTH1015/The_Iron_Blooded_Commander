using System;
using System.Collections.Generic;

[Serializable]
public class StrategyDataTable : IData
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int[] UnitDivisionList { get; set; }
}

public class StrategyDataArray
{
    public List<StrategyDataTable> StrategyDataTable;
}

public class StrategyInfo : AutoSave<StrategyDataArray>
{
    public StrategyInfo() : base("StrategyDataTable") { }
}