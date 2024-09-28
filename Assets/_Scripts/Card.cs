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
    
    public void SetCardText(CardData cardData, CharacterData charcterData)
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
        rightText.text = isRu ? cardData.RightSwipe.swipeData.choiceRu : cardData.RightSwipe.swipeData.choiceEn;
        leftText.text = isRu ? cardData.LeftSwipe.swipeData.choiceRu : cardData.LeftSwipe.swipeData.choiceEn;
    }
    
    public void SetCardText(CardData cardData)
    {
        var isRu = YandexGame.savesData.language == "ru";
        rightText.text = isRu ? cardData.RightSwipe.swipeData.choiceRu : cardData.RightSwipe.swipeData.choiceEn;
        leftText.text = isRu ? cardData.LeftSwipe.swipeData.choiceRu : cardData.LeftSwipe.swipeData.choiceEn;
    }

    public void SetDefaultLeftCardText(CardData cardData)
    {
        var isRu = YandexGame.savesData.language == "ru";
        leftText.text = isRu ? cardData.LeftSwipe.swipeData.choiceRu : cardData.LeftSwipe.swipeData.choiceEn;
    }
    
    public void SetDefaultRightCardText(CardData cardData)
    {
        var isRu = YandexGame.savesData.language == "ru";
        rightText.text = isRu ? cardData.RightSwipe.swipeData.choiceRu : cardData.RightSwipe.swipeData.choiceEn;
    }

    public void SetCardText(CardData.SwipeData swipeData, bool isLeft)
    {
        var isRu = YandexGame.savesData.language == "ru";
        if (isLeft)
            leftText.text = isRu ? swipeData.choiceRu : swipeData.choiceEn;
        else
            rightText.text = isRu ? swipeData.choiceRu : swipeData.choiceEn;
    }
}
