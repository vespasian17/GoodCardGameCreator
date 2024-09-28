using _Scripts;
using _Scripts.Configs;
using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviourSingleton<StatManager>
{
    [SerializeField] private TextMeshProUGUI alice;
    [SerializeField] private TextMeshProUGUI sanity;
    private Stats _stats;
    public Stats StatsList => _stats;
    
    private void Awake()
    {
        _stats = DataManager.Instance.GameStats;
        if (_stats != null)
        {
            StatsList.UnregisterAllHandlers();          //need it for reload scene
            StatsList.OnStatChanged += SetStatToUI;
        }
        else
        {
            Debug.LogError("GameStats is null. Check GameSaveLoader.");
        }
    }

    void Start()
    {
        if (alice is not null && sanity is not null)
        {
            alice.text = StatsList.GetStatValue(StatsType.Alice).CurrentGameValue.ToString();
            sanity.text = StatsList.GetStatValue(StatsType.Sanity).CurrentGameValue.ToString();
        } 
        else if (alice is null) Debug.Log("alice is null. Check StatManager");
        else if (sanity is null) Debug.Log("sanity is null. Check StatManager");
    }

    private void SetStatToUI(StatsType type, int value)
    {
        if (alice == null || sanity == null)
        {
            Debug.Log("UI elements are not assigned.");
            return;
        }

        switch (type)
        {
            case StatsType.Alice:
                alice.text = StatsList.GetStatValue(StatsType.Alice)?.CurrentGameValue.ToString() ?? "0";
                break;
            case StatsType.Sanity:
                sanity.text = StatsList.GetStatValue(StatsType.Sanity)?.CurrentGameValue.ToString() ?? "0";
                break;
        }
    }

    public void OnCardMoved(bool? isLeft)
    {
        var currentCardData = DataManager.Instance.CurrentCard;
        if (currentCardData == null)
            return;

        var statChanges = isLeft == true ? currentCardData.LeftSwipe.statChanges : currentCardData.RightSwipe.statChanges;

        foreach (var stat in statChanges)
        {
            StatsList.ChangeStatValue(stat.type, stat.value);
        }
    }
    
    public void InitializeStats(StatData[] allStatData)
    {
        foreach (var statData in allStatData)
        {
            if (!_stats.ContainsStat(statData.type))
            {
                _stats.AddStatToStats(statData.type, statData.defaultValue, statData.maxValue);
            }
        }
    }

}
