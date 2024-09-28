using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class EventManager : MonoBehaviourSingleton<EventManager>
{
    private GameEventFlags _gameEventFlags;
    public GameEventFlags GameEventFlags => _gameEventFlags;

    private void Awake()
    {
        _gameEventFlags = DataManager.Instance.EventFlags;
    }
    
    public void OnCardMoved(bool? isLeft)
    {
        var currentCardData = DataManager.Instance.CurrentCard;       //убрать привязку к контент сеттеру
        if (currentCardData == null)
            return;

        var swipeSide = isLeft == true ? currentCardData.LeftSwipe : currentCardData.RightSwipe; //get swipe depends on side of swipe
        
        if (swipeSide.eventsHappens is null)
            return;
        
        foreach (var gameEvent in swipeSide.eventsHappens)
        {
            _gameEventFlags.EnableEvent(gameEvent);
            Debug.Log(gameEvent.ToString());
        }
        
        
        if (swipeSide.runEvents is null)
            return;
        
        foreach (var runEvent in swipeSide.runEvents)
        {
            if (_gameEventFlags.CheckTrueCondition(runEvent.eventCondition))
            {
                //если true перекинуть данные свайпа ивента на основной свайп
            }
            return; //Работает только первое вхождение true!!!
            //если много true? добавить множественные варианты
        }
    }

    public void SetSwipeDataOnCurrentCard()
    {
        
    }
    
    
}
