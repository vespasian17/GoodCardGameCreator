using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Configs;
using UnityEngine;

public class CardInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardContainerPosition;
    private SwipeEffect _swipeEffect;           //убрать свайпэффект чтобы повесить 1 скрипт на сцену

    private void Awake()
    {
        _swipeEffect = GetComponent<SwipeEffect>();
        _swipeEffect.CardMoved += OnCardCreated;
    }

    public void SpawnNewCard()
    {
        Instantiate(cardPrefab);
    }

    public void SpawnNewCardAsChild(Transform position)
    {
        //need to improve spawn pos independent from parent position
        var newCard = Instantiate(cardPrefab, position);
        Debug.Log($"SpawnNewCard in parent {position.name}");
        
        newCard.transform.localPosition = new Vector3(0, 0, 1);
        Debug.Log("Set Transform Position");
        
        newCard.transform.rotation = Quaternion.identity;
        Debug.Log("Set Transform Rotation");
    }

    public void OnCardCreated(bool isLeft)
    {
        //realize isLeft function to spawn card
        SpawnNewCardAsChild(cardContainerPosition);
    }
    

    private void OnDestroy()
    {
        _swipeEffect.CardMoved -= OnCardCreated;
    }
}
