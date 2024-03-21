using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Save;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class YandexGameSaveSystem : MonoBehaviour, ISaveSystem
{
    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            Load();
        }
    }

    private void OnEnable() => YandexGame.GetDataEvent += Load;
    private void OnDisable() => YandexGame.GetDataEvent -= Load;
    

    public void Save(SaveData saveData)
    {
        YandexGame.savesData.saveData = saveData;
        YandexGame.SaveProgress();
    }

    public void Load()
    {
        
    }
}
