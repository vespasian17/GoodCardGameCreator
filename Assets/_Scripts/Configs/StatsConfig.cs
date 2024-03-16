using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "StatsConfig", menuName = "Configs/StatsConfig")]
public class StatsConfig : ScriptableObject
{
    [SerializeField] private Stat[] stats;

    public Stat[] GetStats()
    {
        return stats;
    }
        
    [Serializable]
    public class Stat
    {
        public StatsType type;
        public Sprite sprite;
        public string nameRu;
        public string nameEn;
        public Color color;
        public int startValue;
        public int maxValue;
    }
}
