using System;
using UnityEngine;

namespace _Scripts.Configs
{
    [CreateAssetMenu (fileName = "Stat", menuName = "DataFile/Stat")]
    public class StatData : ScriptableObject
    {
        public StatsType type;
        public Sprite sprite;
        public string nameRu;
        public string nameEn;
        public Color color;
        public int currentGameValue;
        public int maxValue;
        public int defaultValue;
    }
}
