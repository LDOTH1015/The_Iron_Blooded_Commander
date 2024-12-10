using System;
using System.Collections.Generic;

[Serializable]
public class UserKnight : KnightDefault, IData
{
    public string KnightID { get; set; }
    public string UserID { get; set; }
}

public class UserKnightDataArray
{
    public List<UserKnight> UserKnight;
}

public class UserKnightInfo : AutoSave<UserKnightDataArray>
{
    public UserKnightInfo() : base("UserKnight") { }
}
