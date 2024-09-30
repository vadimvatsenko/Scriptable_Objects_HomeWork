using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PresetBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject[] _cherboxsItem;
    private ScriptableObject[] _presets;

    private void Awake()
    {
        Debug.Log("Start");
        _presets = Resources.LoadAll<ScriptableObject>("ScriptableObjects/MapPresets");
        foreach (ScriptableObject preset in _presets)
        {
            Debug.Log(preset.name);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach(var checkBox in _cherboxsItem)
        {
            if(checkBox.GetComponent<Toggle>().isOn)
            {
                Debug.Log(checkBox.name);
            }
        }
    }
}
