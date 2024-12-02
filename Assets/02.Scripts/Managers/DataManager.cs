using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IManager
{
    public KnightInfo knightInfo;
    public UnitTypeInfo unitTypeInfo;
    public UnitDivisionInfo unitDivisionnfo;
    public DomainInfo domainInfo;
    public EventInfo eventData;

    public void Initialize()
    {
        domainInfo = new DomainInfo();
        eventData = new EventInfo();
    }
}
