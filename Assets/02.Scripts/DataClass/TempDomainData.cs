using Newtonsoft.Json;
using System.IO;
using UnityEditor.PackageManager;
using UnityEngine;

// 임시 영지 데이터
public class TempDomainData : MonoBehaviour
{
    public DomainArray domainArray;
    public LordDataArray lordDataArray;
    public KnightDataArray knightDataArray;
    public UnitTypeDataArray unitTypeDataArray;
    public StrategyDataArray strategyDataArray;
    public UnitDivisionPositionDataaArray unitDivisionPositionDataArray;
    public UnitDivisionDataArray unitDivisionDataArray;
    public UnitDivisionRoleDataArray unitDivisionRoleDataArray;

    string dataPath = "JsonData/";
    private void Awake()
    {
        SetTempData();
    }
    public void SetTempData()
    {
        domainArray = JsonConvert.DeserializeObject<DomainArray>(LoadData("DomainDataTable"));
        lordDataArray = JsonConvert.DeserializeObject<LordDataArray>(LoadData("LordDataTable"));
        knightDataArray = JsonConvert.DeserializeObject<KnightDataArray>(LoadData("KnightDataTable"));
        unitTypeDataArray = JsonConvert.DeserializeObject<UnitTypeDataArray>(LoadData("UnitTypeDataTable"));
        strategyDataArray = JsonConvert.DeserializeObject<StrategyDataArray>(LoadData("StrategyDataTable"));
        unitDivisionPositionDataArray = JsonConvert.DeserializeObject<UnitDivisionPositionDataaArray>(LoadData("UnitDivisionPositionDataTable"));
        unitDivisionDataArray = JsonConvert.DeserializeObject<UnitDivisionDataArray>(LoadData("UnitDivisionDataTable"));
        unitDivisionRoleDataArray = JsonConvert.DeserializeObject<UnitDivisionRoleDataArray>(LoadData("UnitDivisionRoleDataTable"));
    }
    public string LoadData(string fileName)
    {
        string loadDataPath = Path.Combine(dataPath, fileName);
        Debug.Log($"LoadDataPath: {loadDataPath}");

        TextAsset jsonTextAsset = Resources.Load<TextAsset>(loadDataPath);
        if (jsonTextAsset != null )
        {
            Debug.Log($"Load 성공!");
            return jsonTextAsset.text;
        }
        
        Debug.LogError($"{fileName} 데이터 없음.");
        return "";
    }
}