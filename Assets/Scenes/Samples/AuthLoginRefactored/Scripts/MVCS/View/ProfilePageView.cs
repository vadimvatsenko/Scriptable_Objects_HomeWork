using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AuthLoginSample
{
    public class ProfilePageView : MonoBehaviour, IPageView
    {
        [SerializeField] private TextMeshProUGUI idText;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI emailText;
        [SerializeField] private TextMeshProUGUI passwordText;

        [SerializeField] private Button quitButton;
        [SerializeField] private Button enterGameButton;
        [SerializeField] private Button editUserProfileButton;

        public string ID
        {
            get { return idText.text; }
            set { idText.text = value; }
        }
        public string Name
        {
            get { return nameText.text; }
            set { nameText.text = value; }
        }
        public string Email
        {
            get { return emailText.text; }
            set { emailText.text = value; }
        }
        public string Password
        {
            get { return passwordText.text; }
            set {passwordText.text = value; }
        }

        public Action OnQuitClick;
        public Action OnEnterGameClick;
        public Action OnProfileEditClick;
        public Action OnChangeValue;
 
        public void Hide()
        {
           gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Initialize()
        {
            quitButton.onClick.AddListener(QuitClick);
            enterGameButton.onClick.AddListener(EnterGameClick);
            editUserProfileButton.onClick.AddListener(ProfileEditClick);
        }

        private void QuitClick()
        {
            OnQuitClick?.Invoke();
        }

        private void EnterGameClick()
        {
            OnEnterGameClick?.Invoke();
        }

        private void ProfileEditClick()
        {
            OnProfileEditClick?.Invoke();
        }

        private void ChangeValue()
        {

        }
    }
}
