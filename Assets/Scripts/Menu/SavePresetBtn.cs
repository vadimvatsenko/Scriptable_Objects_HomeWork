using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class SavePresetBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _grassCountField;
    [SerializeField] private TextMeshProUGUI _rocksCountField;
    [SerializeField] private TextMeshProUGUI _treesCountField;
    [SerializeField] private TextMeshProUGUI _speedBuffCountField;
    [SerializeField] private TextMeshProUGUI _healthBuffCountField;

    private List<TextMeshProUGUI> _fieldsList = new List<TextMeshProUGUI>();

    public static event Action<TextAsset> OnSaveJson; // публикация события

    private void Awake()
    {
        _fieldsList = new List<TextMeshProUGUI>()
        {
            _nameField, _grassCountField, _rocksCountField, _treesCountField, _speedBuffCountField, _healthBuffCountField
        };

    }
    public void SaveToJson()
    {
        bool isUnique = ValidateUniqueJson();

        if (!isUnique)
        {
            return;
        }

        MapPresets mapObj = ScriptableObject.CreateInstance<MapPresets>(); // создание ScriptableObject используется CreateInstance

        mapObj._grass = ParceStringToNumber(_grassCountField.text);
        mapObj._rocks = ParceStringToNumber(_rocksCountField.text);
        mapObj._trees = ParceStringToNumber(_treesCountField.text);
        mapObj._speedBuffs = ParceStringToNumber(_speedBuffCountField.text);
        mapObj._healthBufs = ParceStringToNumber(_healthBuffCountField.text);

        string test = JsonUtility.ToJson(mapObj);

        OnSaveJson?.Invoke(new TextAsset(test)); // вызываем событие // new TextAsset(test) - преобразование в TextAsset

        string filePath = Application.dataPath + $"/Resources/JSONS/{_nameField.text}.json";

        File.WriteAllText(filePath, test);
        AssetDatabase.Refresh();
    }

    private bool ValidateUniqueJson()
    {
        TextAsset[] jsonFiles = Resources.LoadAll<TextAsset>("JSONS");

        foreach(var js in jsonFiles)
        {
            if(js.name == _nameField.text)
            {
                return false;
            }

           
        }
        return true;
    }

    private int ParceStringToNumber(string str)
    {
        str = RemoveNonDigitCharacters(str).Trim();
        if(int.TryParse(str, out int number))
        {
            return number;
        }
        else
        {
            Debug.LogError($"{str} wrong parse to int");
            return 0;
        }       
    }

    // Метод для удаления всех символов, кроме цифр
    private string RemoveNonDigitCharacters(string str)
    {
        return new string(str.Where(char.IsDigit).ToArray());
    }

    public void ClearFields()
    {
        
        foreach(var field in _fieldsList)
        {
            //Debug.Log(field.text);
            
        }
    }
}
