using System;
using _Scripts.Save;
using Source.Scripts.Configs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;

namespace _Scripts
{
    public class ContentSetter : MonoBehaviour
    {
        [SerializeField] private CardInstantiator _cardInstantiator;
        [SerializeField] private TextMeshProUGUI textContent;
        private YandexGameSaveSystem _saveSystem;
        private CardData _currentCardData;
        private bool _isGameLoaded;
        private SaveData _saveData;
        
        void Start()
        {
            _saveData = new SaveData();
            _saveSystem = this.AddComponent<YandexGameSaveSystem>();
            SetDataOnLoad();
            _cardInstantiator.CardCreated += OnEnableCard;
        }

        private void OnEnableCard()
        {
            if (_cardInstantiator.IsLeftSwipe == true)              //nullable bool!!!
            {
                Debug.Log("Left Swipe");
                _currentCardData = _currentCardData.LeftSwipe.nextCard;
            }
            else if (_cardInstantiator.IsLeftSwipe == false)
            {
                Debug.Log("Right Swipe");
                _currentCardData = _currentCardData.RightSwipe.nextCard;
            }
            
            if (_currentCardData is not null)
            {
                _cardInstantiator.NewCreatedCard.SetCardData(_currentCardData);
                SetContentData();
            }

            else
            {
                Debug.Log("Карты закончились");
                _cardInstantiator.CardCreated -= OnEnableCard;
            }

            _saveData.savedCardData = _currentCardData;
            _saveSystem.Save(_saveData);
        }

        public void SetDataOnLoad()     //реализация сейв лоад?
        {
            if (_saveData.savedCardData is not null)
                _saveData.savedCardData = _currentCardData;
            else _currentCardData = ChapterLoader.Instance.ChapterCards[0];
        }

        private void SetContentData()
        {
            var isRu = YandexGame.savesData.language == "ru";
            textContent.text = isRu ? _currentCardData.DescriptionRu : _currentCardData.DescriptionEn;
        }
    }
}
