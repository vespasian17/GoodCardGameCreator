using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : IDataService
{
    public bool SaveData<T>(string relativePath, T data)
    {
        var path = "D:/" + relativePath;

        try
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
            return true;
        }
        catch (Exception e)
        {
            Debug.Log($"Unable to save data due to: {e.Message} {e.StackTrace}");
            return false;
        }
    }

    public T LoadData<T>(string relativePath)
    {
        var path = "D:/" + relativePath;

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}. File doesn't exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }

        try
        {
            var fileContent = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(fileContent))
            {
                Debug.LogError($"File at {path} is empty!");
                throw new InvalidOperationException($"File at {path} is empty!");
            }

            T data = JsonConvert.DeserializeObject<T>(fileContent);
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }

    public void DeleteData<T>(string relativePath)
    {
        var path = "D:/" + relativePath;

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.Log($"File at {path} does not exist!");
        }
    }
}
