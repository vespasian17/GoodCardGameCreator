using Source.Scripts.Configs;
using UnityEngine;

[CreateAssetMenu(fileName = "CardsContainer", menuName = "Configs/CardsContainer")]
public class CardsContainer : ScriptableObject
{
    [SerializeField] private CardConfig[] cards;

    public CardConfig[] Cards => cards;
}
