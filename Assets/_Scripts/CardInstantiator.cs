using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardInstantiator : MonoBehaviour                   //Just instancing empty card object
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardContainer;
    [SerializeField] private StatManager statManager;
    private SwipeEffect _swipeEffect;
    private SwipeEffect _newSwipeEffect;
    private Card _newCreatedCard;
    private bool? _isLeft;
    
    public event Action CardCreated;

    public Card NewCreatedCard => _newCreatedCard;
    public bool? IsLeftSwipe => _isLeft;

    private void Start()
    {
        SpawnNewCardAsChild(cardContainer);
        SubscribeOnSwipeEffect();
    }

    private bool ChildsCheck(Transform transform)
    {
        if (transform.childCount > 0) return true;
        return false;
    }

    public void SubscribeOnSwipeEffect()       //Подписка на новый свайп созданной карты
    {
        if (ChildsCheck(cardContainer))
        {
            if (_swipeEffect is null)
            {
                _swipeEffect = cardContainer.GetComponentInChildren<SwipeEffect>();
            }
            else _swipeEffect = _newSwipeEffect;
            _swipeEffect.RegisterHandler(statManager.OnCardMoved);          //Reset handler and Register OnCardMoved
            _swipeEffect.CardMovedToLeft += OnCardCreated;
        }
        else Debug.Log("NoCardsInContainer");
    }

    public void SpawnNewCard()
    {
        Instantiate(cardPrefab);
    }

    public void SpawnNewCardAsChild(Transform position)
    {
        //need to improve spawn pos independent from parent position
        var newCard = Instantiate(cardPrefab, position);
        newCard.transform.localPosition = new Vector3(0, 0, 1);
        newCard.transform.rotation = Quaternion.identity;
        
        _newSwipeEffect = newCard.GetComponent<SwipeEffect>();
        _newCreatedCard = newCard.GetComponent<Card>();
        CardCreated?.Invoke();
    }

    public void OnCardCreated(bool? isLeft)      //вызывается true если влево, false если вправо
    {
        Debug.Log("CardCreated");
        _isLeft = isLeft;
        _swipeEffect.CardMovedToLeft -= OnCardCreated;
        SpawnNewCardAsChild(cardContainer);
        SubscribeOnSwipeEffect();
    }
}
