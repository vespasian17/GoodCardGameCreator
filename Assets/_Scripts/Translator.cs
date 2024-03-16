using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Translator : MonoBehaviour
{
    [SerializeField] string ru;
    [SerializeField] string en;

    private TextMeshProUGUI _textObj;
    private int _value = - 1;

    private void OnEnable()
    {
            
        YandexGame.SwitchLangEvent += UpdateText;
    }

    private void OnDestroy() => YandexGame.SwitchLangEvent -= UpdateText;

    private void Awake()
    {
        _textObj = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText(YandexGame.savesData.language);
    }

    private void UpdateText(string lang)
    {
        switch (lang)
        {
            case "ru":
                _textObj.text = _value == -1 ? ru : $"{ru} {_value}";
                break;
                
            default:
                _textObj.text = _value == -1 ? en : $"{en} {_value}";;
                break;
        }
    }

    public void SetValue(int value)
    {
        _value = value;
        UpdateText(YandexGame.savesData.language);
    }
}
