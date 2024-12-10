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
    public UnitDivisionPositionDataArray unitDivisionPositionDataArray;
    public UnitDivisionDataArray unitDivisionDataArray;
    public UnitDivisionRoleDataArray unitDivisionRoleDataArray;

    string dataPath = "JsonData/";
    private void Awake()
    {
        SetTempData();
    }
    public void SetTempData()
    {
        domainArray = JsonConvert.DeserializeObject<DomainArray>(LoadData("Domain"));
        lordDataArray = JsonConvert.DeserializeObject<LordDataArray>(LoadData("Lord"));
        knightDataArray = JsonConvert.DeserializeObject<KnightDataArray>(LoadData("KnightDefault"));
        unitTypeDataArray = JsonConvert.DeserializeObject<UnitTypeDataArray>(LoadData("UnitType"));
        strategyDataArray = JsonConvert.DeserializeObject<StrategyDataArray>(LoadData("Strategy"));
        unitDivisionPositionDataArray = JsonConvert.DeserializeObject<UnitDivisionPositionDataArray>(LoadData("UnitDivisionPosition"));
        unitDivisionDataArray = JsonConvert.DeserializeObject<UnitDivisionDataArray>(LoadData("UnitDivision"));
        unitDivisionRoleDataArray = JsonConvert.DeserializeObject<UnitDivisionRoleDataArray>(LoadData("UnitDivisionRole"));
    }
    public string LoadData(string fileName)
    {
        string loadDataPath = Path.Combine(dataPath, fileName);
        Debug.Log($"LoadDataPath: {loadDataPath}");

        TextAsset jsonTextAsset = Resources.Load<TextAsset>(loadDataPath);
        if (jsonTextAsset != null )
        {
            Debug.Log($"{fileName}: Load 성공!");
            return jsonTextAsset.text;
        }
        
        Debug.LogError($"{fileName}: 데이터 없음.");
        return "";
    }
    public void SaveData()
    {

    }
}