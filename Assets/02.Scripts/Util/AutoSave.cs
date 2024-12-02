using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
public abstract class AutoSave<T> where T : new()
{
    private string filePath;

    public T Data { get; private set; }

    protected AutoSave(string fileName)
    {
        filePath = Path.Combine(Application.dataPath, $"Resources/JsonData/{fileName}.json");

        if (File.Exists(filePath))
        {
            try
            {
                var json = Resources.Load($"JsonData/{fileName}") as TextAsset;
                Data = JsonConvert.DeserializeObject<T>(json.ToString());
                if (Data == null)
                {
                    Data = new T();
                }
            }
            catch (Exception ex)
            {
                Data = new T();
            }
        }
        else
        {
            Data = new T();
            Save();
        }
    }

    public void Save()
    {
        try
        {
            string json = JsonUtility.ToJson(Data, true);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"{ex.Message}");
        }
    }

    public void Modify(Action<T> modifyAction)
    {
        try
        {
            modifyAction(Data);
            Save();
        }
        catch (Exception ex)
        {
            Debug.LogError($"{ex.Message}");
        }
    }
}
