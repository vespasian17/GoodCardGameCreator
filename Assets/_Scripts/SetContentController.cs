using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetContentController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textContent;
    void Start()
    {
        //Debug.Log(ChapterLoader.Instance.ChapterCards[0].LeftSwipe.choiceRu);
        textContent.text = ChapterLoader.Instance.ChapterCards[0].DescriptionRu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
