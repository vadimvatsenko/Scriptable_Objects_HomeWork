using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForgotPassBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI emailField;

    public static event Action<string> OnForgotPassBtnClicked;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnForgotPassBtnClicked?.Invoke(emailField.text);
    }
}
