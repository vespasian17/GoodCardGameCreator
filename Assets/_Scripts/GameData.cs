using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Configs;
using UnityEngine;

public class GameData
{
    public bool isEnding;
    //public bool useSaveItem;
    public bool lastSwipeIsLeft;
        
    //public CardState cardState;
    public Card card;
    public CardConfig currentCardConfig;
    public CardsContainer currentCardContainer;
    public Transform cardsParent;
        
    //Components
    public List<Card> cards = new List<Card>();
    //public List<ItemComponent> itemComponents = new List<ItemComponent>();

    //Configs
    public Dictionary<Characters, CharacterConfig> characterConfigs = new Dictionary<Characters, CharacterConfig>();
    //public Dictionary<ItemType, ItemConfig> itemConfigs = new Dictionary<ItemType, ItemConfig>();
    public Dictionary<EndGameTypes, EndingConfig> endingConfigs = new Dictionary<EndGameTypes, EndingConfig>();
        
    //Other
    public StatsType StatsType = new StatsType();
    //public List<ItemType> activeItems = new List<ItemType>();
}
