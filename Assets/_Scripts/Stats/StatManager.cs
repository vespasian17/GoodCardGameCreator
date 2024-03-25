using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviourSingleton<StatManager>
{
    [SerializeField] private TextMeshProUGUI alice;
    [SerializeField] private TextMeshProUGUI sanity;
    private Stats _stats = new Stats();
    public Stats StatsList => _stats;
    
    private void Awake()
    {
        _stats = GameSaveLoader.Instance.SaveData.Stats;
        _stats.OnStatChanged += SetStatToUI;
    }

    void Start()
    {
        if (alice is not null && sanity is not null)
        {
            alice.text = _stats.GetStat(StatsType.Alice).currentGameValue.ToString();
            sanity.text = _stats.GetStat(StatsType.Sanity).currentGameValue.ToString();
        }
    }

    private void SetStatToUI(StatsType type, int value)
    {
        if (alice is not null && sanity is not null)
        {
            switch (type)
            {
                case StatsType.Alice:
                    alice.text = _stats.GetStat(StatsType.Alice).currentGameValue.ToString();
                    break;
                case StatsType.Sanity:
                    sanity.text = _stats.GetStat(StatsType.Sanity).currentGameValue.ToString();
                    break;
            }
        }
    }

    public void OnCardMoved(bool? isLeft)
    {
        if (ContentSetter.Instance.CurrentCardData is not null)
        {
            if (isLeft == true)
            {
                foreach (var stat in ContentSetter.Instance.CurrentCardData.LeftSwipe.statChanges)
                {
                    _stats.ChangeStat(stat.type, stat.value);
                }
            }
            else                 
                foreach (var stat in ContentSetter.Instance.CurrentCardData.RightSwipe.statChanges)
                {
                    _stats.ChangeStat(stat.type, stat.value);
                }
        }
    }

}
