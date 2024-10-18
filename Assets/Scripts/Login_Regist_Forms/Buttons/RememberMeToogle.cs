using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class RememberMeToogle : MonoBehaviour
{
    private Toggle _toggle;

    void Awake()
    {
        _toggle = GetComponent<Toggle>();
        // Загружаем сохранённое состояние при запуске
        if (PlayerPrefs.HasKey("ToggleState"))
        {
            bool isOn = PlayerPrefs.GetInt("ToggleState") == 1;
            _toggle.isOn = isOn;
        }

        // Подписываемся на событие изменения состояния
        _toggle.onValueChanged.AddListener(SaveToggleState);
    }

    // Сохранение состояния Toggle
    void SaveToggleState(bool isOn)
    {
        PlayerPrefs.SetInt("ToggleState", isOn ? 1 : 0);
        PlayerPrefs.Save(); // Необязательно, PlayerPrefs.Save() вызывается автоматически
    }
}
