using _Scripts.Configs;
using UnityEngine;

public class ChapterLoader : MonoBehaviourSingleton<ChapterLoader>
{
    private CardData[] _chapterCards;
    private CharacterData[] _characters;
    private StatData[] _statsData;

    public CardData[] ChapterCards => _chapterCards;
    public CharacterData[] Characters => _characters;
    public StatData[] StatsData => _statsData;

    private void Awake()
    {
        //need to realise load saved card
        //Можно подгружать 1 объект, ссылки работают
        _statsData = Resources.LoadAll<StatData>("Stats");
        _chapterCards = Resources.LoadAll<CardData>("AliceSpeech");
        _characters = Resources.LoadAll<CharacterData>("Characters");
    }
}
