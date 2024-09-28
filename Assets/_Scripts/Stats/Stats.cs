using System;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    private Dictionary<StatsType, Stat> statsDictionary = new(100); // 100 KeyValue pairs
    public event Action<StatsType, int> OnStatChanged;

    public void AddStatToStats(StatsType type, int defaultValue, int maxValue)
    {
        if (!statsDictionary.ContainsKey(type))
        {
            var stat = new Stat(defaultValue, maxValue);
            statsDictionary.Add(type, stat);
        }
    }

    public void ChangeStatValue(StatsType type, int value) // Change value of KeyStats
    {
        if (statsDictionary.TryGetValue(type, out var stat))
        {
            var newValue = Mathf.Clamp(stat.CurrentGameValue + value, 0, stat.MaxValue);
            stat.ChangeCurrentGameValue(newValue);
            OnStatChanged?.Invoke(type, stat.CurrentGameValue);
        }
        else
        {
            Debug.LogWarning($"Stat of type {type} does not exist.");
        }
    }

    public Stat GetStatValue(StatsType type)
    {
        statsDictionary.TryGetValue(type, out var stat);
        return stat;
    }

    public void ResetStats()
    {
        foreach (var stat in statsDictionary.Values)
        {
            stat.ResetValue();
        }
    }

    public Dictionary<StatsType, int> GetStatsDataForSaving()
    {
        var dictionaryForSaving = new Dictionary<StatsType, int>();
        foreach (var stat in statsDictionary)
        {
            dictionaryForSaving.Add(stat.Key, stat.Value.CurrentGameValue);
        }

        return dictionaryForSaving;
    }

    public bool ContainsStat(StatsType type)
    {
        return statsDictionary.ContainsKey(type);
    }
    
    public void SetStatValue(StatsType type, int newValue)
    {
        if (statsDictionary.TryGetValue(type, out var stat))
        {
            var clampedValue = Mathf.Clamp(newValue, 0, stat.MaxValue); // Ограничиваем значение
            stat.ChangeCurrentGameValue(clampedValue);
            OnStatChanged?.Invoke(type, stat.CurrentGameValue);
        }
        else
        {
            Debug.LogWarning($"Stat of type {type} does not exist.");
        }
    }

    public void UnregisterAllHandlers()
    {
        OnStatChanged = null;
    }
}
