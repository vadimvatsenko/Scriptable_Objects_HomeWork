using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifyPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _errorLabel;
    [SerializeField] TextMeshProUGUI _errorMessage;

    private void Start()
    {
        /*_errorLabel = this.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _errorMessage = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();*/
    }
    public void ShowNotificationMessage(string title, string message)
    {   
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
