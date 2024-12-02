using System;
using System.IO;
using UnityEngine;
public abstract class AutoSave<T> where T : new()
{
    private string filePath;

    public T[] Data { get; private set; }

    protected AutoSave(string fileName)
    {
        filePath = Path.Combine(Application.dataPath, $"Resources/JsonData/{fileName}.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Data = JsonUtility.FromJson<Wrapper<T>>(json).Items;
        }
        else
        {
            Data = new T[0];
            Save();
        }
    }

    public void Save()
    {
        var wrapper = new Wrapper<T> { Items = Data };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(filePath, json);

        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }

    public void Modify(Action<T[]> modifyAction)
    {
        modifyAction(Data);
        Save();
    }

    [Serializable]
    private class Wrapper<U>
    {
        public U[] Items;
    }
}
