using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IData
{
    string ID { get; }
}
public class DataManager : IManager
{
    public DomainInfo domainInfo;
    public EventInfo eventInfo;
    public EventResultInfo eventResultInfo;
    public KnightInfo knightInfo;
    public LordInfo lordInfo;
    public RewardInfo rewardInfo;
    public StageInfo stageInfo;
    public StrategyInfo strategyInfo;
    public UnitDivisionInfo unitDivisionInfo;
    public UnitDivisionPositionInfo unitDivisionPositionInfo;
    public UnitDivisionRoleInfo unitDivisionroleInfo;
    public UnitTypeInfo unitTypeInfo;
    public UserInfo userInfo;
    public UserKnightInfo userKnightInfo;
    public UserUnitTypeInfo userUnitTypeInfo;
    public void Initialize()
    {
        // TODO: 저장된 데이터 불러오기랑 새게임 시 새로운 플레이어데이터만들기. 두 가지 경우가 있기때문에 조건식달아야함
        //제이슨데이터 자체를 수정하는 방법. 사용할때 조심하길!
        // domainInfo.Modify(data => 
        // { 
        //     data.DomainDataTable[0].Name = ""; 
        // });
        domainInfo = new DomainInfo();
        eventInfo = new EventInfo();
        eventResultInfo = new EventResultInfo();
        knightInfo = new KnightInfo();
        lordInfo = new LordInfo();
        rewardInfo = new RewardInfo();
        stageInfo = new StageInfo();
        strategyInfo = new StrategyInfo();
        unitDivisionInfo = new UnitDivisionInfo();
        unitDivisionPositionInfo = new UnitDivisionPositionInfo();
        unitDivisionroleInfo = new UnitDivisionRoleInfo();
        unitTypeInfo = new UnitTypeInfo();
        userInfo = new UserInfo();
        userKnightInfo = new UserKnightInfo();
        userUnitTypeInfo = new UserUnitTypeInfo();
    }

    public T FindDataById<T>(List<T> dataList, string id) where T : IData
    {
        foreach (T data in dataList)
        {
            if (data.ID == id)
                return data;
        }
        return default;
    }
}
