using UnityEngine;

[CreateAssetMenu(fileName = "CardsContainer", menuName = "Configs/CardsContainer")]
public class CardsContainer : ScriptableObject
{
    [SerializeField] private CardData[] cards;

    public CardData[] Cards => cards;
}
