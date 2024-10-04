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
        TextAsset[] jsonFiles = Resources.LoadAll<TextAsset>("JSONS");
        _checkBoxPrefab = Resources.Load<GameObject>("Prefabs/CheckBox/ChackBoxPrefab");
        
        foreach (var jsonFile in jsonFiles)
        {
            GameObject _checkbox = GameObject.Instantiate(_checkBoxPrefab);
            
            _checkbox.name = jsonFile.name;
            _checkbox.transform.SetParent(GameObject.Find("CheckBoxGroup").transform);
            _checkbox.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = jsonFile.name;
            _checkbox.AddComponent<CheckboxInfo>().SaveJsonToCheckBox(jsonFile);
            
            _checkbox.transform.localScale = Vector3.one * 0.1f;
        }
    }
}
