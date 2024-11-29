using System;

[Serializable]
public class UnitDivisionRoleData
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string RoleID { get; set; }
    public int Condition { get; set; }
    public int SupportUnit { get; set; }
}

[Serializable]
public class UnitDivisionRoleInfo
{
    public UnitDivisionRoleData[] UnitTypeDatas;
}