using System;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "DataFile/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] [BoxGroup("Main")] private Color defaultCardColor;
    [SerializeField] [BoxGroup("Main")] private Sprite cardSprite;

    [SerializeField] [BoxGroup("Character")] private bool withCharacter;
    [SerializeField] [BoxGroup("Character")] [ShowIf("withCharacter")] private Characters character;

    [SerializeField] [BoxGroup("Next Container Of Cards")] private bool nextContainer;
    [SerializeField] [BoxGroup("Next Container Of Cards")] [ShowIf("nextContainer")] private CardsContainer cardsContainer;
        
    [SerializeField] [BoxGroup("Random Next Card")] private bool randomNextCard;
    [SerializeField] [BoxGroup("Random Next Card")] [ShowIf("randomNextCard")] private CardsContainer cardsContainerRandom;
        
    [SerializeField] [BoxGroup("Description")] [TextArea(3,5)] private string descriptionRu;
    [SerializeField] [BoxGroup("Description")] [TextArea(3,5)] private string descriptionEn;

    [SerializeField] [BoxGroup("Left Swipe")] private Swipe leftSwipe;
    [SerializeField] [BoxGroup("Right Swipe")] private Swipe rightSwipe;

    [SerializeField] [BoxGroup("Ending")] private EndGameTypes endGameType;
    [SerializeField] [BoxGroup("Ending")] private bool isLastCard;

    //Main
    public Color DefaultCardColor => defaultCardColor;
    public Sprite CardSprite => cardSprite;
        
    //Description
    public string DescriptionEn => descriptionEn;
    public string DescriptionRu => descriptionRu;
        
    //Character
    public bool WithCharacter => withCharacter;
    public Characters CharacterType => character;

    //Chain Of Cards
    public bool NextContainer => nextContainer;
    public CardsContainer CardContainer => cardsContainer;
        
    //Next Random Card
    public bool RandomNextCard => randomNextCard;
    public CardsContainer CardContainerRandom => cardsContainerRandom;

    //Swipes
    public Swipe LeftSwipe => leftSwipe;
    public Swipe RightSwipe => rightSwipe;
        
    //Ending
    public EndGameTypes EndingType => endGameType;
    public bool IsLastCard => isLastCard;

    [Serializable]
    public struct Swipe
    {
        public CardData nextCard;
        public string choiceRu;
        public string choiceEn;
        public StatChange[] statChanges;
    }

    [Serializable]
    public struct StatChange
    { 
        public StatsType type;
        public int value;
    }
}
