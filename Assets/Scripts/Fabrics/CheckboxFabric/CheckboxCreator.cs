using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckboxCreator : MonoBehaviour
{
    private CheckBoxFabric _checkBoxFabric;
    
    private void Awake()
    {
        _checkBoxFabric = new CheckBoxFabric();
        _checkBoxFabric.GetInputsInfo();
    }
}
