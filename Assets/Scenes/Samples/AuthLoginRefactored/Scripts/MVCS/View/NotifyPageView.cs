
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AuthLoginSample
{
    public class NotifyPageView : MonoBehaviour, IPageView
    {
        [SerializeField] private TextMeshProUGUI _errorLabel;
        [SerializeField] private TextMeshProUGUI _errorMessage;
        [SerializeField] private Button _closeButton;

        public void Hide()
        {
            Debug.Log("Noty Hide");
            _errorLabel.text = " ";
            _errorMessage.text = " ";
            this.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            _closeButton.onClick.AddListener(Hide);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void ShowMessage(string title, string message, Color color)
        {
            _errorLabel.color = color;
            _errorMessage.color = color;
            _errorLabel.text = title;
            _errorMessage.text = message;

            Show();
        }

        
    }
}

