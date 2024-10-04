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
        //GameObject[] _cherboxsItem = GameObject.Find("CheckBoxGroup").transform.GetComponentsInChildren<GameObject>();

        TextAsset json = (_testCheckbox.GetComponent<CheckboxInfo>().checkboxJson);

        JsonUtility.FromJsonOverwrite(json.ToString(), _mapPresets);



        /*foreach (var checkBox in _cherboxsItem)
        {
            if(checkBox.GetComponent<Toggle>().isOn)
            {
                
                JsonUtility.FromJsonOverwrite(json.ToString(), _presets);
            }
        }*/
    }
}
