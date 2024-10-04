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

    public void SaveToJson()
    {
        MapPresets mapObj = ScriptableObject.CreateInstance<MapPresets>();

        mapObj._grass = ParceStringToNumber(_grassCountField.text);
        mapObj._rocks = ParceStringToNumber(_rocksCountField.text);
        mapObj._trees = ParceStringToNumber(_treesCountField.text);
        mapObj._speedBuffs = ParceStringToNumber(_speedBuffCountField.text);
        mapObj._healthBufs = ParceStringToNumber(_healthBuffCountField.text);

        string test = JsonUtility.ToJson(mapObj);
        Debug.Log(test);

        string filePath = Application.dataPath + $"/Resources/JSONS/{_nameField.text}.json";

        File.WriteAllText(filePath, test);
        AssetDatabase.Refresh();
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
}
