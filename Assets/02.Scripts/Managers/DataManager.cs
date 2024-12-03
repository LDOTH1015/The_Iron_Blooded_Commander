using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IManager
{
    public KnightInfo knightInfo;
    public UnitTypeInfo unitTypeInfo;
    public UnitDivisionInfo unitDivisionnfo;
    public UnitDivisionRoleInfo unitDivisionrole;
    public DomainInfo domainInfo;
    public EventInfo eventData;

    public void Initialize()
    {
        knightInfo = new KnightInfo();
        unitTypeInfo = new UnitTypeInfo();
        unitDivisionnfo = new UnitDivisionInfo();
        unitDivisionrole = new UnitDivisionRoleInfo();
        domainInfo = new DomainInfo();
        eventData = new EventInfo();

        //domainInfo.Modify()
    }
}
