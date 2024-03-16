using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class ContentSetter : MonoBehaviour
    {
        [SerializeField] private CardInstantiator _cardInstantiator;
        [SerializeField] private TextMeshProUGUI textContent;

        void Start()
        {
            _cardInstantiator.GetCreatedCard().SetCardData(ChapterLoader.Instance.ChapterCards[0], ChapterLoader.Instance.Characters[0]);
        }

        public void OnEnableCard()
        {
            _cardInstantiator.GetCreatedCard().SetCardData(ChapterLoader.Instance.ChapterCards[0], ChapterLoader.Instance.Characters[0]); 
            //Текущая карта получена, в нее устанавливаются данные (нужно настроить добавление конкретной карты в зависимости от свайпа)
            //Нулл референс GetCreatedCard
        }
    
    }
}
