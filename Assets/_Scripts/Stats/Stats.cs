using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Stats
{
    private Dictionary<StatsType, Stat> _stats = new Dictionary<StatsType, Stat>(); //Пустой словарь <StatsType, Stat>
    private List<Stat> _statsList = new List<Stat>();                               //Пустой лист <Stat>

    //public Stat ZeroStat => _statsList.FirstOrDefault(stat => stat.currentGameValue <= 0); 
    public event Action<StatsType, int> OnStatChanged;                             //Объявление события

    public void AddStat(StatsType type, int startValue, int maxValue)
    {
        var stat = new Stat(type, startValue, maxValue);                    //Создается объект Stat
        _stats.Add(type, stat);                                                       //В словарь добавляется объект Stat
        _statsList.Add(stat);                                                         //В стат лист добавляется Stat
    }
    

    public void ChangeStat(StatsType type, int value)                                           //Изменение стата StatType type на значение value
    {
        var stat = _stats[type];                                                                //из словаря берется переменная stat с ключом type
        var newValue = Mathf.Clamp(stat.currentGameValue + value, 0, stat.maxValue);    //создается переменная newValue которая хранит в себе значение обновленного value
        stat.currentGameValue = newValue;                                                           //в значение игрового value записывается новое value
        OnStatChanged?.Invoke(type, stat.currentGameValue);                                        //вызов события OnStatChanged
    }

    public Stat GetStat(StatsType type)
    {
        return _stats[type];
    }

}
