using System;
using UnityEngine;

namespace _Scripts.Configs
{
    [CreateAssetMenu (fileName = "Stat", menuName = "DataFile/Stat")]
    public class StatData : ScriptableObject
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
}
