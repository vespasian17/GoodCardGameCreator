using System;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public Dictionary<StatsType, Stat> _statsDictionary = new(100);          // 100 KeyValue pairs
    public event Action<StatsType, int> OnStatChanged;

    public void AddStat(StatsType type, int startValue, int maxValue)
    {
        var stat = new Stat( startValue, maxValue);                    
        _statsDictionary.Add(type, stat);                                                     
    }

    public void ChangeStat(StatsType type, int value)               // Change value of KeyStats
    {
        var stat = _statsDictionary[type];                                                                
        var newValue = Mathf.Clamp(stat.currentGameValue + value, 0, stat.maxValue);    
        stat.currentGameValue = newValue;                                                           
        OnStatChanged?.Invoke(type, stat.currentGameValue);                                        
    }

    public Stat GetStat(StatsType type)
    {
        return _statsDictionary[type];
    }
}
