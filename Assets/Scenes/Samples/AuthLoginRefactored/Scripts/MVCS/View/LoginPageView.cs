namespace AuthLoginSample.View
{
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class LoginPageView : MonoBehaviour, IPageView // �������� �����������
{
        [SerializeField] private TextMeshProUGUI loginText; // ���� �����
        [SerializeField] private TextMeshProUGUI passwordText; // ���� ������

        [SerializeField] private Button registrationButton; // ������ �����������
        [SerializeField] private Button loginButton;
        [SerializeField] private Toggle _rememberMeToggle;

        public string Email => loginText.text;
        public string Password => passwordText.text;

        public Action OnRegisterClicked; // ������� �� ������� ������ �����������
        public Action OnLoginClicked;

        public void Hide()
        {
            gameObject.SetActive(false); // ��������
        }

        public void Show()
        {
            gameObject.SetActive(true); // ��������
        }

        public void Initialize()
        {
            registrationButton.onClick.AddListener(OnRegisterClickedUnity); // ������������ �����, ������� ����� �������� ����� OnRegisterClickedUnity � �� ����� �������� �������
            loginButton.onClick.AddListener(OnLoginClickedUnity);
        }

        private void OnRegisterClickedUnity()
        {
            OnRegisterClicked?.Invoke();
        }

        private void OnLoginClickedUnity()
        {
            OnLoginClicked?.Invoke();
        }
    }
}