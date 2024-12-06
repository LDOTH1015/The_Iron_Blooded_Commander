using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// 전면 중지. 아직 안 쓰는 부분
public class WorldDB : MonoBehaviour
{
    public string worldName = "World1";
    public int worldID = 20000;
    public int playerID = 2200;

    public DomainInfo domainInfo;
    public KnightInfo knightInfo;
    public UnitTypeInfo unitTypeInfo;
    public StrategyInfo strategyInfo;
    public UnitDivisionRoleInfo unitDivisionrole;
    public UnitDivisionPositionInfo unitDivisionPositionInfo;
    public UnitDivisionInfo unitDivisionInfo;

    private void Awake()
    {
        
    }

    //public List<WorldDB> worldDBList = new List<WorldDB>();
    private void Start()
    {
        //LocatorManager.Instance.dataManager.knightInfo.Data.KnightDataTable[0].
        //domainInfo = new DomainInfo();
        //domainInfo.Modify(data => data.DomainDataTable[0].ID = 0);
    }

    public void SaveWorld()
    {

    }

    public void LoadWorld()
    {

    }

    public void SaveDomainArmy(DomainArmy domainArmy)
    {
        //domainInfo.Data.
    }

    public void LoadDomainArmy(DomainArmy domainArmy)
    {
        //domainInfo.Data.
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
public class WorldDataTable : IData
{
    public int ID {  get; set; }
    public string WorldName { get; set; }
    public int PlayerID { get; set; }
}
public class WorldDataArray
{
    public List<WorldDataTable> worldDataTable;
}
public class WorldData : AutoSave<KnightDataArray>
{
    public WorldData(string dataBaseName) : base(dataBaseName) { }
}
//public class KnightData : AutoSave<KnightDataArray>
//{
//    public KnightData(string dataBaseName) : base(dataBaseName) { }
//}