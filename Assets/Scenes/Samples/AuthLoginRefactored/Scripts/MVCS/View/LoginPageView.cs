namespace AuthLoginSample
{
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class LoginPageView : MonoBehaviour, IPageView // страница логинизации
{
        [SerializeField] private TextMeshProUGUI loginText; // поле почты
        [SerializeField] private TextMeshProUGUI passwordText; // поле пароля

        [SerializeField] private Button registrationButton; // кнопка регистрации
        [SerializeField] private Button loginButton;
        [SerializeField] private Toggle rememberMeToggle;

        public string Email => loginText.text;
        public string Password => passwordText.text;

        public Action OnRegisterClicked; // событие по нажатию кнопки регистрации
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
            gameObject.SetActive(false); // спрятать
        }

        public void Show()
        {
            gameObject.SetActive(true); // показать
        }

        public void Initialize()
        {
            registrationButton.onClick.AddListener(OnRegisterClickedUnity); // регистрируем метод, который будет вызывать метод OnRegisterClickedUnity и он будет вызывать событие
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