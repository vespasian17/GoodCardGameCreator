using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Configs;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private CardConfig _currentCardElement;
    private CardConfig _nextCardElement;

    private SwipeEffect _currentCardSwipe;
    
    public SwipeEffect CurrentCardSwipe
    {
        get => _currentCardSwipe;
        set => _currentCardSwipe = value;
    }

    void Start()
    {
        _currentCardSwipe.CardMoved += LoadDataFromScriptableObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadDataFromScriptableObject(bool isLeft)
    {
        //if (isLeft)
            //_nextCardElement = _currentCardElement.LeftSwipe
    }
}
