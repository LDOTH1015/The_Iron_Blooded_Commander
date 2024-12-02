using System;

[Serializable]
public class EventData
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

[Serializable]
public class EventInfo : AutoSave<EventData>
{
    public EventInfo() : base("EventData") { }
}