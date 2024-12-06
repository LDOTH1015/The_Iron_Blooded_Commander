using System;
using System.Collections.Generic;

[System.Serializable]
public class RewardDataTable
{
    public string ID;
    public int Stage;
    public string ItemType;
    public int RewardNum;
    public string Icon;
}
public class RewardDataArray
{
    public List<RewardDataTable> KnightDataTable;
}

public class RewardInfo : AutoSave<RewardDataArray>
{
    public RewardInfo() : base("RewardDataTable") { }
}