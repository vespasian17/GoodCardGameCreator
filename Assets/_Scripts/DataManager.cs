using System;
using System.IO;
using _Scripts.Configs;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace _Scripts
{
    public class DataManager : MonoBehaviourSingletonPersistent<DataManager>
    {
        private readonly IDataService _dataSaveService = new JsonDataService();
        private readonly string _defaultCardPath = "Chapters/0. Awake/NewGamePoint";
        
        private SaveData _saveData = new SaveData();                // Contains all data for saving
        private Stats _gameStats = new Stats();     //Maybe need to create file GameData with fields like Stats, Chars, Cards etc
        private GameEventFlags _eventFlags = new GameEventFlags();
        
        private CardData _currentCard;
        private CharacterData[] _characters;
        private StatData[] _statsData;
    
        public SaveData SaveData => _saveData;
        public Stats GameStats => _gameStats;
        public IDataService DataSaveService => _dataSaveService;
        public CardData CurrentCard => _currentCard;
        public CharacterData[] Characters => _characters;
        public StatData[] StatsData => _statsData;
        public GameEventFlags EventFlags => _eventFlags;

        public event Action OnChapterLoaded;
        
        
        private new void Awake()
        {
            base.Awake();
            
            //Load default resources//
            _statsData = Resources.LoadAll<StatData>("Stats");
            _currentCard = Resources.Load<CardData>(_defaultCardPath);
            _characters = Resources.LoadAll<CharacterData>("Characters");
            
            _eventFlags.FillEventsDictionary();
            
            OnChapterLoaded?.Invoke();
        }

        private void SaveDataToFile()
        {
            if (_dataSaveService.SaveData("/player-stats.json", _saveData))
            {
            
            }
            else
            {
                Debug.LogError("Could not save file! Show something on UI about it!");
            }
        }

        public void LoadSavedStatsFromFile()  // Continue button
        {
            GameStats.ResetStats();

            foreach (var stat in StatsData)                      
            {
                GameStats.AddStatToStats(stat.type, stat.defaultValue, stat.maxValue);
            }
            
            _saveData = _dataSaveService.LoadData<SaveData>("/player-stats.json");

            if (_saveData != null && _saveData.SavedStats.Count > 0)
            {
                foreach (var savedStat in _saveData.SavedStats)
                {
                    GameStats.SetStatValue(savedStat.Key, savedStat.Value);
                }
            }
            else
            {
                Debug.LogWarning("No saved data found or saved data is empty.");
            }
        }
        
        public void LoadSavedCard()
        {
            string savedPath = SaveData.CardPath;
            if (!string.IsNullOrEmpty(savedPath))
            {
                LoadCard(savedPath); // Загружаем сохранённую карту
            }
            else
            {
                LoadCard(_defaultCardPath); // Если сохранение отсутствует, загружаем дефолтную карту
            }
        }
        
        private void UpdateSavedCard(CardData card)
        {
            _saveData.SaveCardPath(AssetDatabase.GetAssetPath(card));
        }
    
        private void UpdateSavedStats(Stats stats)
        {
            _saveData.SaveStats(stats);
        }
        
        private void LoadCard(string path)
        {
            _currentCard = Resources.Load<CardData>(path);
        }

        public void ResetStats()
        {
            GameStats.ResetStats();
            foreach (var stat in StatsData)                      
            {
                GameStats.AddStatToStats(stat.type, stat.defaultValue, stat.maxValue);
            }
        }

        public void ResetCard()
        {
            LoadCard(_defaultCardPath);
        }
        
        public void SaveGame()
        {
            UpdateSavedCard(CurrentCard);                               // Обновляет данные карты для сохранения
            UpdateSavedStats(StatManager.Instance.StatsList);           // Обновляет данные статов для сохранения
            SaveDataToFile();                                           // Сохраняет в файл json
        }

        public void SetNextCard(CardData cardData)
        {
            _currentCard = cardData;
        }
    }
}
