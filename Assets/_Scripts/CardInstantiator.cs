using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Configs;
using UnityEngine;

public class CardInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardContainer;
    private SwipeEffect _swipeEffect;
    private SwipeEffect _newSwipeEffect;
    private Card _newCreatedCard;

    public Card NewCreatedCard => _newCreatedCard;
    

    private void Awake()
    {
        //_swipeEffect.CardMoved += OnCardCreated;
    }

    private void Start()
    {
        SubscribeOnSwipeEffect();
    }

    private bool ChildsCheck(Transform transform)
    {
        if (transform.childCount > 0) return true;
        return false;
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
            _swipeEffect.CardMoved += OnCardCreated;
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
    }

    public void OnCardCreated(bool isLeft)
    {
        _swipeEffect.CardMoved -= OnCardCreated;
        //realize isLeft function to spawn card
        SpawnNewCardAsChild(cardContainer);
        SubscribeOnSwipeEffect();
    }

    public Card GetCreatedCard()
    {
        return NewCreatedCard;
    }
}
