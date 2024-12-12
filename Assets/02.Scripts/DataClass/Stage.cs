using System;
using System.Collections.Generic;

[Serializable]
public class Stage : IData
{
    public string ID { get; set; }
    public string DmainID { get; set; }
    public string Round { get; set; }
}

public class StageDataArray
{
    public List<Stage> Stage;
}

public class StageInfo : AutoSave<StageDataArray>
{
    public StageInfo() : base("Stage") { }
}
