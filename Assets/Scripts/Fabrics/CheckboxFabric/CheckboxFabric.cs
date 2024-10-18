using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxFabric
{
    private GameObject _checkBoxPrefab;
    private GameObject _parent;

    public CheckBoxFabric()
    {
        SavePresetBtn.OnSaveJson += AddNewCheckBox;
        _parent = GameObject.Find("CheckBoxGroup");
    }

    ~CheckBoxFabric()
    {
        SavePresetBtn.OnSaveJson -= AddNewCheckBox;
    }
    public void GetInputsInfo()
    {
        
        TextAsset[] jsonFiles = Resources.LoadAll<TextAsset>("JSONS");
        _checkBoxPrefab = Resources.Load<GameObject>("Prefabs/CheckBox/ChackBoxPrefab");
        
        foreach (var jsonFile in jsonFiles)
        {
            CreateCheckboxes(_parent, jsonFile);
        }
    }

    private void CreateCheckboxes(GameObject parent, TextAsset jsonFile)
    {
        Debug.Log("Create");
        GameObject _checkbox = GameObject.Instantiate(_checkBoxPrefab, parent.transform);
        _checkbox.GetComponent<Toggle>().group = parent.GetComponent<ToggleGroup>();
        _checkbox.name = jsonFile.name;
        _checkbox.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = jsonFile.name;
        _checkbox.transform.GetChild(2).AddComponent<DeletePresetBtn>();
        _checkbox.AddComponent<CheckboxInfo>().SaveJsonToCheckBox(jsonFile);
    }

    private void AddNewCheckBox(TextAsset json)
    {
        Debug.Log("Add CheckBox");
        CreateCheckboxes(_parent, json);
    }
}
