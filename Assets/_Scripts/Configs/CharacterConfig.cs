using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CharacterScriptableObject", menuName = "ScriptableObject/CharacterScriptableObject")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private Characters type;
    [SerializeField] private string nameRu;
    [SerializeField] private string nameEn;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Color cardColor;
        
    public Characters Type => type;
    public Sprite Sprite => sprite;
    public Color CardColor => cardColor;

    public string GetName(string language)
    {
        return language == "ru" ? nameRu : nameEn;
    }
}
