namespace AuthLoginSample
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
        [SerializeField] private Toggle rememberMeToggle;

        public string Email => loginText.text;
        public string Password => passwordText.text;

        public Action OnRegisterClicked; // ������� �� ������� ������ �����������
        public Action OnLoginClicked;
        public Action<bool> OnRememberMeToggleClicked;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnLoginClicked?.Invoke();
            }
        }

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
            rememberMeToggle.onValueChanged.AddListener(OnRememberMeClickedUnity);
        }

        private void OnRememberMeClickedUnity(bool arg0)
        {
            OnRememberMeToggleClicked?.Invoke(arg0);
        }

        private void OnDisable()
        {
            registrationButton.onClick.RemoveAllListeners();
            loginButton.onClick.RemoveAllListeners();
            rememberMeToggle.onValueChanged.RemoveAllListeners();
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