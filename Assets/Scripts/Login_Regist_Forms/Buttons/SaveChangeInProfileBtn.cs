using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveChangeInProfileBtn : MonoBehaviour, IPointerClickHandler
{
    public static event Action OnClickSaveProfile;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickSaveProfile?.Invoke();
    }
}
