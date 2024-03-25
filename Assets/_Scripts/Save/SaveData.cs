using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    private Stats _stats = new Stats();
    public Stats Stats => _stats;
    public CardData savedCard;      //Change to ID

    public void SetStats(Stats newStats)
    {
        _stats = newStats;
    }
}
