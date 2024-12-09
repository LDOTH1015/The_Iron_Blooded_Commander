using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IData
{
    int ID { get; }
}
public class DataManager : IManager
{
    public KnightInfo knightInfo;
    public UnitTypeInfo unitTypeInfo;
    public StrategyInfo strategyInfo;
    public RewardInfo rewardInfo;
    public UnitDivisionPositionInfo unitDivisionPositionInfo;
    public UnitDivisionInfo unitDivisionnfo;
    public UnitDivisionRoleInfo unitDivisionrole;
    public DomainInfo domainInfo;
    public EventInfo eventData;

    public void Initialize()
    {
        // TODO: 저장된 데이터 불러오기랑 새게임 시 새로운 플레이어데이터만들기. 두 가지 경우가 있기때문에 조건식달아야함

        knightInfo = new KnightInfo();
        unitTypeInfo = new UnitTypeInfo();
        strategyInfo = new StrategyInfo();
        rewardInfo = new RewardInfo();
        unitDivisionPositionInfo = new UnitDivisionPositionInfo();
        unitDivisionnfo = new UnitDivisionInfo();
        unitDivisionrole = new UnitDivisionRoleInfo();
        domainInfo = new DomainInfo();
        eventData = new EventInfo();

        //제이슨데이터 자체를 수정하는 방법. 사용할때 조심하길!
        // domainInfo.Modify(data => 
        // { 
        //     data.DomainDataTable[0].Name = ""; 
        // });

        Debug.Log(FindDataById(knightInfo.Data.KnightDataTable,1000).NameKr);
    }

    public T FindDataById<T>(List<T> dataList, int id) where T : IData
    {
        foreach (T data in dataList)
        {
            if (data.ID == id)
                return data;
        }
        return default;
    }
}
