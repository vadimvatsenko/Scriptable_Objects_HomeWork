using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "MapPreset", menuName = "Map/Presets")]
public class MapPresets : ScriptableObject
{
    public int _trees;
    public int _rocks;
    public int _grass;

    public int _speedBuffs;
    public int _healthBufs;

    private void LoadFromJson(string fileName) // � ������ ������ �������� ���, �� ����� id ���
    {
        string filePath = Application.dataPath + $"/Resources/JSONS/{fileName}.json";

        if (File.Exists(filePath))
        {
            // ������ JSON-�����
            string jsonData = File.ReadAllText(filePath);

            // �������������� JSON � ������
            MapPresets mapObj = JsonUtility.FromJson<MapPresets>(jsonData);

            _trees = mapObj._trees;
            _rocks = mapObj._rocks;
            _grass = mapObj._grass;
            _speedBuffs = mapObj._speedBuffs;
            _healthBufs = mapObj._healthBufs;
        }
        else
        {
            Debug.LogError($"File not found at {filePath}");
            
        }
    }
}
