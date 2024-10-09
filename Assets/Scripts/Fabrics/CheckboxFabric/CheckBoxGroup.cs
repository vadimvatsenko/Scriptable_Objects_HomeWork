using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxGroup : MonoBehaviour
{
    public GameObject GetActiveToggle()
    {
        Toggle[] toggles = this.GetComponentsInChildren<Toggle>();
        GameObject toogleIsOn = this.GetComponentsInChildren<Toggle>().FirstOrDefault(toggle => toggle.isOn).gameObject;
        return toogleIsOn;
    }
}
