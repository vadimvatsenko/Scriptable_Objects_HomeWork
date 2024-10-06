using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PresetBtn : MonoBehaviour, IPointerClickHandler
{    
    private ScriptableObject _presets;
    [SerializeField] GameObject _testCheckbox;
    [SerializeField] MapPresets _mapPresets;

    private void Awake()
    {
        _presets = Resources.Load<ScriptableObject>("ScriptableObjects/MapPresets");
    }

    public void OnPointerClick(PointerEventData eventData)
    {      
        TextAsset json = _testCheckbox.GetComponent<CheckboxInfo>().checkboxJson;
        JsonUtility.FromJsonOverwrite(json.ToString(), _mapPresets);
    }
}
