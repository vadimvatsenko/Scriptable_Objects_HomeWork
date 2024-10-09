using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// общий скрипт, который будет висеть на checkbox после создания
public class CheckboxInfo : MonoBehaviour
{
    public event Action deleteCheckBox;
    public TextAsset checkboxJson {  get; private set; }
    public string id;

    private void OnEnable()
    {
        deleteCheckBox += DeleteCheckBox;
    }
    public void SaveJsonToCheckBox(TextAsset json)
    {
        checkboxJson = json;
    }

    private void DeleteCheckBox()
    {
        Destroy(this);
    }
}
