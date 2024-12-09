using System;
using System.Collections.Generic;

[Serializable]
public class EventResult : IData
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string EventID { get; set; }
    public int ResultValue { get; set; }
}

public class EventResulttDataArray
{
    public List<EventResult> EventResult;
}

public class EventResultInfo : AutoSave<EventResulttDataArray>
{
    public EventResultInfo() : base("EventResult") { }
}
