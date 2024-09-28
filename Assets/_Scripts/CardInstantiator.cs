using System;
using UnityEngine;

public class CardInstantiator : MonoBehaviourSingleton<CardInstantiator> 
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardContainer;
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
        return transform.childCount > 0;
    }

    private void SubscribeOnSwipeEffect()
    {
        if (ChildsCheck(cardContainer))
        {
            if (_swipeEffect is null)
            {
                _swipeEffect = cardContainer.GetComponentInChildren<SwipeEffect>();
            }
            else _swipeEffect = _newSwipeEffect;

            _swipeEffect.RegisterHandler(StatManager.Instance.OnCardMoved);
            _swipeEffect.RegisterHandler(EventManager.Instance.OnCardMoved);
            _swipeEffect.CardMovedToLeft += OnCardCreated;
        }
        else Debug.Log("NoCardsInContainer");
    }

    private void SpawnNewCardAsChild(Transform position)
    {
        var newCard = Instantiate(cardPrefab, position);
        newCard.transform.localPosition = new Vector3(0, 0, 1);
        newCard.transform.rotation = Quaternion.identity;

        _newSwipeEffect = newCard.GetComponent<SwipeEffect>();
        _newCreatedCard = newCard.GetComponent<Card>();
        CardCreated?.Invoke();
    }

    private void OnCardCreated(bool? isLeft)
    {
        Debug.Log("CardCreated");
        _isLeft = isLeft;
        _swipeEffect.CardMovedToLeft -= OnCardCreated;
        SpawnNewCardAsChild(cardContainer);
        SubscribeOnSwipeEffect();
    }
}