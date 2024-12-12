using System;
using System.Collections.Generic;

[Serializable]
public class Strategy : IData
{
    public string ID { get; set; }
    public string DomainID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class StrategyDataArray
{
    public List<Strategy> Strategy;
}

public class StrategyInfo : AutoSave<StrategyDataArray>
{
    public StrategyInfo() : base("Strategy") { }
}
