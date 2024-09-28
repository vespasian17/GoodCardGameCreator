using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SaveData
{
    private Dictionary<StatsType, int> _savedStats = new();
    [JsonProperty]
    public Dictionary<StatsType, int> SavedStats => _savedStats;
    
    private string _cardPath = "";
    [JsonProperty]
    public string CardPath
    {
        get => _cardPath;
        set => _cardPath = value;
    }
    
    public void SaveStats(Stats newStats)
    {
        _savedStats = newStats.GetStatsDataForSaving();
    }

    public void SaveCardPath(string newCardPath)
    {
        var pathSegments = newCardPath.Split(new[] { "Assets/Resources/" }, StringSplitOptions.RemoveEmptyEntries);
    
        if (pathSegments.Length > 0)
        {
            string cleanedPath = pathSegments[0];
            _cardPath = Path.ChangeExtension(cleanedPath, null);
        }
        else
        {
            _cardPath = newCardPath;
        }
    }

    public SaveData()
    {
        
    }
}
