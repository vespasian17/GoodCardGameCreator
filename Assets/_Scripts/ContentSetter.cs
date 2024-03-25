using TMPro;
using UnityEngine;
using YG;

public class ContentSetter : MonoBehaviourSingleton<ContentSetter>
{
    private CardInstantiator _cardInstantiator;
    [SerializeField] private TextMeshProUGUI textContent;
    private CardData _currentCardData;
    private bool _isGameLoaded;

    public CardData CurrentCardData => _currentCardData;
        
    void Start()
    {
        _cardInstantiator = CardInstantiator.Instance;
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
    }
    
    public void SaveGame()
    {
        //GameSaveLoader.Instance.UpdateSavedCard(_currentCardData);                             // Обновляет данные карты для сохранения
        GameSaveLoader.Instance.UpdateSavedStats(StatManager.Instance.StatsList);           // Обновляет данные статов для сохранения
        GameSaveLoader.Instance.SaveDataToFile();                                           // Сохраняет в файл json
    }

    public void SetDataOnLoad()     // Устанавливает в значение текущей карты первую карту при загрузке сцены
    {
        _currentCardData = ChapterLoader.Instance.ChapterCards[0];
    }

    private void SetContentData()      // устанавливает описание вариантов выбора в карточку
    {
        var isRu = YandexGame.savesData.language == "ru";
        textContent.text = isRu ? _currentCardData.DescriptionRu : _currentCardData.DescriptionEn;
    }
}

