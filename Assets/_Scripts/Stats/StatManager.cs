using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using TMPro;
using UnityEngine;
using YG;

public class StatManager : MonoBehaviourSingleton<StatManager>
{
    [SerializeField] private ChapterLoader _chapterLoader;
    [SerializeField] private ContentSetter _contentSetter;
    [SerializeField] private TextMeshProUGUI alice;
    [SerializeField] private TextMeshProUGUI sanity;
    private Stats _stats;
    
    public Stats StatsList => _stats;
    
    private void Awake()
    {
        _stats = new Stats();
        _stats.OnStatChanged += SetStatToUI;
    }

    void Start()
    {
        foreach (var stat in _chapterLoader.StatsData)
        {
            _stats.AddStat(stat.type, stat.startValue, stat.maxValue);
        }

        if (alice is not null && sanity is not null)
        {
            alice.text = _stats.GetStat(StatsType.Alice).currentGameValue.ToString();
            sanity.text = _stats.GetStat(StatsType.Sanity).currentGameValue.ToString();
        }
    }

    private void SetStatToUI(StatsType type, int value)
    {
        if (alice is not null && sanity is not null)
        {
            switch (type)
            {
                case StatsType.Alice:
                    alice.text = _stats.GetStat(StatsType.Alice).currentGameValue.ToString();
                    break;
                case StatsType.Sanity:
                    sanity.text = _stats.GetStat(StatsType.Sanity).currentGameValue.ToString();
                    break;
            }
        }
    }

    public void OnCardMoved(bool? isLeft)
    {
        if (_contentSetter.CurrentCardData is not null)
        {
            if (isLeft == true)
            {
                foreach (var stat in _contentSetter.CurrentCardData.LeftSwipe.statChanges)
                {
                    _stats.ChangeStat(stat.type, stat.value);
                }
            }
            else                 
                foreach (var stat in _contentSetter.CurrentCardData.RightSwipe.statChanges)
                {
                    _stats.ChangeStat(stat.type, stat.value);
                }

        }
    }

}
