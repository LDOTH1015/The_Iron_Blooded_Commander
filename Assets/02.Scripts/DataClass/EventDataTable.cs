using System;

[Serializable]
public class EventDataTable
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MinClearTime { get; set; }
    public int MaxClearTime { get; set; }
    public string EarlyCompletionPhrase { get; set; }
    public string DelayedCompletionPhrase { get; set; }
    public int StartDay { get; set; }
}

public class EventDataArray
{
    public EventDataTable[] EventDataTable;
}

public class EventInfo : AutoSave<EventDataTable>
{
    public EventInfo() : base("EventDataTable") { }
}