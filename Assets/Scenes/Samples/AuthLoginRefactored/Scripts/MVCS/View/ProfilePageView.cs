﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AuthLoginSample
{
    public class ProfilePageView : MonoBehaviour, IPageView
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI emailText;

        [SerializeField] private Button quitButton;
        [SerializeField] private Button enterGameButton;
        [SerializeField] private Button editUserProfileButton;

        public string Name => nameText.text;
        public string Email => emailText.text;

        public Action OnQuitClick;
        public Action OnEnterGameClick;
        public Action OnProfileEditClick;

 
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
    }
}
