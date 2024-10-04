using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckboxInfo : MonoBehaviour
{
    public TextAsset checkboxJson {  get; private set; }


    public void SaveJsonToCheckBox(TextAsset json)
    {
        checkboxJson = json;
    }
}
