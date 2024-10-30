using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifyPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _errorLabel;
    [SerializeField] TextMeshProUGUI _errorMessage;

    public void ShowNotificationMessage(string title, string message, Color color)
    {   
        _errorLabel.color = color;
        _errorMessage.color = color;
        _errorLabel.text = title;
        _errorMessage.text = message;

        this.gameObject.SetActive(true);
    }

    public void CloseNotify()
    {
        _errorLabel.text = " ";
        _errorMessage.text = " ";

        this.gameObject.SetActive(false);
    }
}
