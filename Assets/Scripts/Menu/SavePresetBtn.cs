using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class SavePresetBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private TextMeshProUGUI _grassCountField;
    [SerializeField] private TextMeshProUGUI _rocksCount;
    [SerializeField] private TextMeshProUGUI _treesCount;
    [SerializeField] private TextMeshProUGUI _speedBuffCount;
    [SerializeField] private TextMeshProUGUI _healthBuffCount;

    [SerializeField] private Text _testTest;

    public void SaveToJson()
    {


        MapPresets mapObj = ScriptableObject.CreateInstance<MapPresets>();




        mapObj._grass = 500;


        mapObj._rocks = 10;
        mapObj._trees = 100;
        mapObj._healthBufs = 300;
        mapObj._speedBuffs = 700;

        string test = JsonUtility.ToJson(mapObj);
        Debug.Log(test);

        string filePath = Application.dataPath + $"/Resources/JSONS/{_nameField.text}.json";

        File.WriteAllText(filePath, test);
        AssetDatabase.Refresh();

    }

    public void LoadToJson()
    {

    }
}
