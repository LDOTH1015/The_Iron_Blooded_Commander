using System;
using System.Collections.Generic;

[Serializable]
public class EventDataTable : IData
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MinClearTime { get; set; }
    public int MaxClearTime { get; set; }
    public string EarlyCompletionPhrase { get; set; }
    public string DelayedCompletionPhrase { get; set; }
    public int DueDate { get; set; }
    public float ResultValue { get; set; }
    public string ResultType { get; set; }
}

public class EventDataArray
{
    public List<EventDataTable> EventDataTable;
}

public class EventInfo : AutoSave<EventDataArray>
{
    public EventInfo() : base("EventDataTable") { }
}