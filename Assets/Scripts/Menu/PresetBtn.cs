using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PresetBtn : MonoBehaviour, IPointerClickHandler
{    
    private ScriptableObject _preset; 
    private GameObject _activeToogle;
    
    private void Awake()
    {
        _preset = Resources.Load<ScriptableObject>("ScriptableObjects/MapPresets/MapPreset"); // �������� ScriptableObject ��������������� � Resources
    }

    public void OnPointerClick(PointerEventData eventData) // �� ������� ������, �������� �������� �������
    {
        _activeToogle = FindAnyObjectByType<CheckBoxGroup>().GetActiveToggle();
        TextAsset json = _activeToogle.GetComponent<CheckboxInfo>().checkboxJson; // �������� Json �� ��������� ��������

        JsonUtility.FromJsonOverwrite(json.ToString(), _preset); // ������� ������� ������������ ������ � ScriptableObject
        // ��� ������ �����, �� ����� json � �������� ������ ������ ������� ��������

        SceneManager.LoadScene(1);
    }
}
