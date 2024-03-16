using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Configs;
using UnityEngine;

public class ChapterLoader : MonoBehaviourSingleton<ChapterLoader>
{
    private CardConfig[] _chapterCards;
    private CharacterConfig[] _characters;

    public CardConfig[] ChapterCards => _chapterCards;
    public CharacterConfig[] Characters => _characters;

    private void Awake()
    {
        _chapterCards = Resources.LoadAll<CardConfig>("AliceSpeech");
        _characters = Resources.LoadAll<CharacterConfig>("Characters");
    }
}
