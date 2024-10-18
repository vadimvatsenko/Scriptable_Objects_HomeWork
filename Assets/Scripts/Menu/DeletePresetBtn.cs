using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;

// удаление Json из asset
public class DeletePresetBtn : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject currentCheckBox = GetComponentInParent<CheckboxInfo>().gameObject;

        TextAsset[] jsonsList = Resources.LoadAll<TextAsset>("JSONS");

        string basePath = "Assets/Resources/JSONS";

        foreach (var json in jsonsList)
        {
            Debug.Log(json.name);

            if(currentCheckBox.name.ToLower() == json.name.ToLower())
            {
                AssetDatabase.DeleteAsset(basePath + $"/{json.name}.json");
            }
        }
        AssetDatabase.Refresh();
        Destroy(currentCheckBox);

    }
}
