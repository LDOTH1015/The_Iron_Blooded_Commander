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
    public UnitDivisionPositionInfo unitDivisionPositionInfo;
    public UnitDivisionInfo unitDivisionnfo;
    public UnitDivisionRoleInfo unitDivisionrole;
    public DomainInfo domainInfo;
    public EventInfo eventData;

    public void Initialize()
    {
        knightInfo = new KnightInfo();
        unitTypeInfo = new UnitTypeInfo();
        strategyInfo = new StrategyInfo();
        unitDivisionPositionInfo = new UnitDivisionPositionInfo();
        unitDivisionnfo = new UnitDivisionInfo();
        unitDivisionrole = new UnitDivisionRoleInfo();
        domainInfo = new DomainInfo();
        eventData = new EventInfo();

        //»ç¿ë¹ý
        domainInfo.Modify(data => 
        { 
            data.DomainDataTable[0].Name = ""; 
        });

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
