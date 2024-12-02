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
        // TODO: 저장된 데이터 불러오기랑 새게임 시 새로운 플레이어데이터만들기. 두 가지 경우가 있기때문에 조건식달아야함
        domainInfo = new DomainInfo();
        eventData = new EventInfo();
    }
}
