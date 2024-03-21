using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CharacterData", menuName = "DataFile/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private Characters person;
    [SerializeField] private string nameRu;
    [SerializeField] private string nameEn;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Color cardColor;
        
    public Characters Person => person;
    public Sprite Sprite => sprite;
    public Color CardColor => cardColor;

    public string GetName(string language)
    {
        return language == "ru" ? nameRu : nameEn;
    }
}
