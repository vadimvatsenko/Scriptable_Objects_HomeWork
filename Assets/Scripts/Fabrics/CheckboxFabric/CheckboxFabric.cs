using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class CheckBoxFabric
{
    private GameObject _checkBoxPrefab;

    public void GetInputsInfo()
    {
        GameObject parent = GameObject.Find("CheckBoxGroup");
        TextAsset[] jsonFiles = Resources.LoadAll<TextAsset>("JSONS");
        _checkBoxPrefab = Resources.Load<GameObject>("Prefabs/CheckBox/ChackBoxPrefab");
        
        foreach (var jsonFile in jsonFiles)
        {
            GameObject _checkbox = GameObject.Instantiate(_checkBoxPrefab, parent.transform);            
            _checkbox.name = jsonFile.name;
            _checkbox.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = jsonFile.name;
            _checkbox.AddComponent<CheckboxInfo>().SaveJsonToCheckBox(jsonFile);
        }
    }
}
