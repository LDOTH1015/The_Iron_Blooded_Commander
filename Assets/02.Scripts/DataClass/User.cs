using System;
using System.Collections.Generic;

[Serializable]
public class User : IData
{
    public string ID { get; set; }
    public string Password { get; set; }
}
public class UserDataArray
{
    public List<User> UserKnight;
}


public class UserInfo : AutoSave<UserDataArray>
{
    public UserInfo() : base("User") { }
}