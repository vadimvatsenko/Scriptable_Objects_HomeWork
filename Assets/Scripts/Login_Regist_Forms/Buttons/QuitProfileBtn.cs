using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitProfileBtn : MonoBehaviour, IPointerClickHandler
{
    public static event Action OnQuitBtnClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnQuitBtnClick?.Invoke();
    }
}
