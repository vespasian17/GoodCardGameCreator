using _Scripts;
using TMPro;
using UnityEngine;
using YG;


public class ContentSetter : MonoBehaviourSingleton<ContentSetter>
{
    private CardInstantiator _cardInstantiator;
    [SerializeField] private TextMeshProUGUI textContent;
    private bool _isGameLoaded;
        
    void Start()
    {
        _cardInstantiator = CardInstantiator.Instance;
        _cardInstantiator.CardCreated += OnEnableCard;
    }

    private void OnEnableCard()
    {
        SetNextCard();

        if (DataManager.Instance.CurrentCard != null)   //добавить проверку на события
        {
            _cardInstantiator.NewCreatedCard.SetCardText(DataManager.Instance.CurrentCard);
            SetEventTextIfHasActiveEvent();
            
            SetTextContentData();
        }
        else
        {
            Debug.Log("Карты закончились");
            _cardInstantiator.CardCreated -= OnEnableCard;
        }
    }

    private void SetTextContentData()
    {
        var isRu = YandexGame.savesData.language == "ru";
        textContent.text = isRu ? DataManager.Instance.CurrentCard.DescriptionRu : DataManager.Instance.CurrentCard.DescriptionEn;
    }
    
    private void SetEventTextIfHasActiveEvent()
    {
        if (DataManager.Instance.CurrentCard.LeftSwipe.runEvents.Length > 0)
        {
            var isEventHappened = false;
            foreach (var gameEvent in DataManager.Instance.CurrentCard.LeftSwipe.runEvents)
            {
                if (isEventHappened) return;
                if (EventManager.Instance.GameEventFlags.EventFlags[gameEvent.eventCondition])
                {
                    _cardInstantiator.NewCreatedCard.SetCardText(gameEvent.swipeData, true);
                    isEventHappened = true;
                }
            }
        }
        
        
        if (DataManager.Instance.CurrentCard.RightSwipe.runEvents.Length > 0)
        {
            var isEventHappened = false;
            foreach (var gameEvent in DataManager.Instance.CurrentCard.RightSwipe.runEvents)
            {
                if (isEventHappened) return;
                if (EventManager.Instance.GameEventFlags.EventFlags[gameEvent.eventCondition])
                {
                    _cardInstantiator.NewCreatedCard.SetCardText(gameEvent.swipeData, false);
                    isEventHappened = true;
                }
            }
        }
    }

    private void SetNextCard()      //устанавливает следующую карту в зависимости от входных данных С УЧЕТОМ СОБЫТИЙ!
    {
        var currentCard = DataManager.Instance.CurrentCard;
        
        if (_cardInstantiator.IsLeftSwipe == true)      //nullable bool
        {
            var isEventHappened = false;
            if (DataManager.Instance.CurrentCard.LeftSwipe.runEvents.Length > 0)
            {
                foreach (var gameEvent in DataManager.Instance.CurrentCard.LeftSwipe.runEvents)
                {
                    if (isEventHappened) return;
                    if (EventManager.Instance.GameEventFlags.EventFlags[gameEvent.eventCondition])
                    {
                        DataManager.Instance.SetNextCard(gameEvent.swipeData.nextCard);
                        isEventHappened = true;
                    }
                }
            }
            if (!isEventHappened)
                DataManager.Instance.SetNextCard(currentCard.LeftSwipe.swipeData.nextCard);     //устанавливает следующую карту как текущую
        }
        else if (_cardInstantiator.IsLeftSwipe == false)
        {
            var isEventHappened = false;
            if (DataManager.Instance.CurrentCard.RightSwipe.runEvents.Length > 0)       //если у текущей карты есть проверка на события
            {
                foreach (var gameEvent in DataManager.Instance.CurrentCard.RightSwipe.runEvents)
                {
                    if (isEventHappened) return;
                    if (EventManager.Instance.GameEventFlags.EventFlags[gameEvent.eventCondition])
                    {
                        DataManager.Instance.SetNextCard(gameEvent.swipeData.nextCard);
                        isEventHappened = true;
                    }
                }
            }
            if (!isEventHappened)
                DataManager.Instance.SetNextCard(currentCard.RightSwipe.swipeData.nextCard);
        }
    }
}

