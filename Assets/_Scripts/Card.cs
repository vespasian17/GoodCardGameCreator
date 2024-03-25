using TMPro;
using UnityEngine;
using YG;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer icon;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector3 characterIconPos = new Vector3(0,0,0);
    
    
    private SwipeEffect _swipeEffect;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetCardData(CardData cardData, CharacterData charcterData)
    {
        if (charcterData != null)
        {
            //back.DOColor(characterConfig.CardColor, animDuration);
            //icon.sprite = charcterData.Sprite;
            //icon.transform.localPosition = characterIconPos;
        }
        else
        {
            //back.DOColor(cardData.DefaultCardColor, animDuration);
            //icon.sprite = cardData.CardSprite;
            //icon.transform.localPosition = Vector3.zero;
        }
            
        var isRu = YandexGame.savesData.language == "ru";
        rightText.text = isRu ? cardData.RightSwipe.choiceRu : cardData.RightSwipe.choiceEn;
        leftText.text = isRu ? cardData.LeftSwipe.choiceRu : cardData.LeftSwipe.choiceEn;
    }
    
    public void SetCardData(CardData cardData)
    {
        var isRu = YandexGame.savesData.language == "ru";
        rightText.text = isRu ? cardData.RightSwipe.choiceRu : cardData.RightSwipe.choiceEn;
        leftText.text = isRu ? cardData.LeftSwipe.choiceRu : cardData.LeftSwipe.choiceEn;
    }
}
