using System;
using System.Collections.Generic;

[Serializable]
public class UnitDivisionRole : IData
{
    public string ID { get; set; }
    public string UnitDivisionID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string RoleID { get; set; }
    public int Condition { get; set; }
    public int SupportUnit { get; set; }
}


public class UnitDivisionRoleDataArray
{
    public List<UnitDivisionRole> UnitDivisionRoleDataTable;
}

public class UnitDivisionRoleInfo : AutoSave<UnitDivisionRoleDataArray>
{
    public UnitDivisionRoleInfo() : base("UnitDivisionRoleDataTable") { }
}