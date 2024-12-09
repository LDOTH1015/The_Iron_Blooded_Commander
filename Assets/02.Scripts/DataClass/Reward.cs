using System;
using System.Collections.Generic;

[System.Serializable]
public class Reward
{
    public string ID;
    public string StageID;
    public string ItemType;
    public int RewardNum;
    public string Icon;
}
public class RewardDataArray
{
    public List<Reward> Reward;
}

public class RewardInfo : AutoSave<RewardDataArray>
{
    public RewardInfo() : base("Reward") { }
}