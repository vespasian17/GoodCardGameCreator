using UnityEngine;

public class GameSaveLoader : MonoBehaviourSingleton<GameSaveLoader>
{
    private SaveData _saveData = new SaveData();                // Contains all data for saving
    private readonly IDataService _dataSaveService = new JsonDataService();
    
    public SaveData SaveData => _saveData;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveDataToFile()
    {
        if (_dataSaveService.SaveData("/player-stats.json", _saveData))
        {
            
        }
        else
        {
            Debug.LogError("Could not save file! Show something on UI about it!");
        }
    }

    public void LoadSaveDataFromFile()                                                  // Continue button
    {
        _saveData = _dataSaveService.LoadData<SaveData>("/player-stats.json");
        Debug.Log("Loaded");
    }

    public void StartNewGame()                                                          // New Game button
    {
        _saveData.Stats._statsDictionary.Clear();
        foreach (var stat in ChapterLoader.Instance.StatsData)                      
        {
            _saveData.Stats.AddStat(stat.type, stat.startValue, stat.maxValue);
        }
    }
    

    public void UpdateSavedCard(CardData card)
    {
        _saveData.savedCard = card;
    }
    
    public void UpdateSavedStats(Stats stats)
    {
        _saveData.SetStats(stats);
    }
}
