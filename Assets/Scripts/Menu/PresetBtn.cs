using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PresetBtn : MonoBehaviour, IPointerClickHandler
{    
    private ScriptableObject _preset; 
    private GameObject _activeToogle;
    
    private void Awake()
    {
        _preset = Resources.Load<ScriptableObject>("ScriptableObjects/MapPresets/MapPreset"); // получаем ScriptableObject непосредственно с Resources
    }

    public void OnPointerClick(PointerEventData eventData) // по нажатию кнопки, получаем активный чекбокс
    {
        _activeToogle = FindAnyObjectByType<CheckBoxGroup>().GetActiveToggle();
        TextAsset json = _activeToogle.GetComponent<CheckboxInfo>().checkboxJson; // получаем Json из активного чекбокса

        JsonUtility.FromJsonOverwrite(json.ToString(), _preset); // утилита котора€ переписывает данные в ScriptableObject
        // что делает метод, он берет json и измен€ет второй обьект который передали

        SceneManager.LoadScene(1);
    }
}
