using System;
using System.Collections.Generic;

[Serializable]
public class UnitDivisionRoleDataTable
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string RoleID { get; set; }
    public int Condition { get; set; }
    public int SupportUnit { get; set; }
}


public class UnitDivisionRoleDataArray
{
    public List<UnitDivisionRoleDataTable> UnitDivisionRoleDataTable;
}

public class UnitDivisionRoleInfo : AutoSave<UnitDivisionDataArray>
{
    public UnitDivisionRoleInfo() : base("UnitDivisionRoleDataTable") { }
}