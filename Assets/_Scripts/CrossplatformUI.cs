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
        if (_backgroundContainer == null)
        {
            Debug.LogError("Контейнер фона не назначен!");
            return;
        }

        var image = _backgroundContainer.GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("Компонент Image отсутствует в контейнере фона!");
            return;
        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            image.sprite = _phoneDevice;
            Debug.Log("Тип устройства: Handheld");
        }
        else if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            image.sprite = _pcDevice;
            Debug.Log("Тип устройства: Desktop");
        }
    }
}