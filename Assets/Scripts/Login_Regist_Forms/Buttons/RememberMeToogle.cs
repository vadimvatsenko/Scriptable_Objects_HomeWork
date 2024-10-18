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
        // ��������� ���������� ��������� ��� �������
        if (PlayerPrefs.HasKey("ToggleState"))
        {
            bool isOn = PlayerPrefs.GetInt("ToggleState") == 1;
            _toggle.isOn = isOn;
        }

        // ������������� �� ������� ��������� ���������
        _toggle.onValueChanged.AddListener(SaveToggleState);
    }

    // ���������� ��������� Toggle
    void SaveToggleState(bool isOn)
    {
        PlayerPrefs.SetInt("ToggleState", isOn ? 1 : 0);
        PlayerPrefs.Save(); // �������������, PlayerPrefs.Save() ���������� �������������
    }
}
