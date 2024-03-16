using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Configs;
using UnityEngine;

public class ChapterLoader : MonoBehaviourSingleton<ChapterLoader>
{
    private CardConfig[] _chapterCards;

    public CardConfig[] ChapterCards => _chapterCards;

    private void Awake()
    {
        _chapterCards = Resources.LoadAll<CardConfig>("AliceSpeech");
        Debug.Log(_chapterCards[0].DescriptionRu);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
