using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossplatformUI : MonoBehaviour
{
    [SerializeField] private Sprite _phoneDevice;
    [SerializeField] private Sprite _pcDevice;
    [SerializeField] private GameObject _backgroundContainer;
    void Start()
    {
        BackgroundSetter();
    }
    

    public void BackgroundSetter()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            _backgroundContainer.GetComponent<Image>().sprite = _phoneDevice;
            Debug.Log(DeviceType.Handheld);
            Debug.Log(SystemInfo.deviceType);
        }

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            _backgroundContainer.GetComponent<Image>().sprite = _pcDevice;
            Debug.Log(DeviceType.Handheld);
            Debug.Log(SystemInfo.deviceType);
        }
    }
}
