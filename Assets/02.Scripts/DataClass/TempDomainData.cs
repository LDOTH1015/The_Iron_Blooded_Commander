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
    string resourcesDataPath = "JsonData/";
    private void Awake()
    {
        SetTempArmyData();
        //LoadArmyData();
        //SaveArmyData();
    }
    public void SetTempArmyData()
    {
        domainArray = JsonConvert.DeserializeObject<DomainArray>(ResourcesLoadData("Domain"));
        lordDataArray = JsonConvert.DeserializeObject<LordDataArray>(ResourcesLoadData("Lord"));
        knightDataArray = JsonConvert.DeserializeObject<KnightDataArray>(ResourcesLoadData("KnightDefault"));
        unitTypeDataArray = JsonConvert.DeserializeObject<UnitTypeDataArray>(ResourcesLoadData("UnitType"));
        strategyDataArray = JsonConvert.DeserializeObject<StrategyDataArray>(ResourcesLoadData("Strategy"));
        unitDivisionPositionDataArray = JsonConvert.DeserializeObject<UnitDivisionPositionDataArray>(ResourcesLoadData("UnitDivisionPosition"));
        unitDivisionDataArray = JsonConvert.DeserializeObject<UnitDivisionDataArray>(ResourcesLoadData("UnitDivision"));
        unitDivisionRoleDataArray = JsonConvert.DeserializeObject<UnitDivisionRoleDataArray>(ResourcesLoadData("UnitDivisionRole"));
    }
    public void SaveArmyData()
    {
        // 초기 데이터를 복사하여 저장
        SaveData(domainArray, "TempSaveDomainData");
        SaveData(lordDataArray, "TempSaveLordData");
        SaveData(knightDataArray, "TempSaveKnightData");
        SaveData(unitTypeDataArray, "TempSaveUnitTypeData");
        SaveData(strategyDataArray, "TempSaveStrategyData");
        SaveData(unitDivisionPositionDataArray, "TempSaveUnitDivisionPositionData");
        SaveData(unitDivisionDataArray, "TempSaveUnitDivisionData");
        SaveData(unitDivisionRoleDataArray, "TempSaveUnitDivisionRoleData");
    }
    public void LoadArmyData()
    {
        domainArray = JsonConvert.DeserializeObject<DomainArray>(ResourcesLoadData("TempSaveDomainData"));
        lordDataArray = JsonConvert.DeserializeObject<LordDataArray>(ResourcesLoadData("TempSaveLordData"));
        knightDataArray = JsonConvert.DeserializeObject<KnightDataArray>(ResourcesLoadData("TempSaveKnightData"));
        unitTypeDataArray = JsonConvert.DeserializeObject<UnitTypeDataArray>(ResourcesLoadData("TempSaveUnitTypeData"));
        strategyDataArray = JsonConvert.DeserializeObject<StrategyDataArray>(ResourcesLoadData("TempSaveStrategyData"));
        unitDivisionPositionDataArray = JsonConvert.DeserializeObject<UnitDivisionPositionDataArray>(ResourcesLoadData("TempSaveUnitDivisionPositionData"));
        unitDivisionDataArray = JsonConvert.DeserializeObject<UnitDivisionDataArray>(ResourcesLoadData("TempSaveUnitDivisionData"));
        unitDivisionRoleDataArray = JsonConvert.DeserializeObject<UnitDivisionRoleDataArray>(ResourcesLoadData("TempSaveUnitDivisionRoleData"));
    }


    public string ResourcesLoadData(string fileName)
    {
        string loadDataPath = Path.Combine(resourcesDataPath, fileName);
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

    // TODO : (Application.persistentDataPath)에 맞춰서 로드하도록 수정해야 함
    public string LoadData(string fileName)
    {
        string loadDataPath = Path.Combine(dataPath, fileName);
        Debug.Log($"LoadDataPath: {loadDataPath}");

        TextAsset jsonTextAsset = Resources.Load<TextAsset>(loadDataPath);
        if (jsonTextAsset != null)
        {
            Debug.Log($"{fileName}: Load 성공!");
            return jsonTextAsset.text;
        }

        Debug.LogError($"{fileName}: 데이터 없음.");
        return "";
    }
    public void SaveData<T>(T data, string fileName)
    {
        // 직렬화
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        // 저장 경로 지정 (Application.persistentDataPath)
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
            Debug.Log($"저장경로 생성: {Application.persistentDataPath}");
        }
        string savePath = Path.Combine(Application.persistentDataPath, $"{fileName}.json");

        // 파일 저장
        File.WriteAllText(savePath, json);
        Debug.Log($"Data saved to {savePath}");
    }
}