namespace AuthLoginSample
{
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class RegistrationPageView : MonoBehaviour, IPageView
{
        [SerializeField] private TextMeshProUGUI loginText; // ���� ����� �����������
        [SerializeField] private TextMeshProUGUI passwordText; // ���� ������

        [SerializeField] private Button backButton; // ������ �������
        [SerializeField] private Button registrationButton; // ������ �����������
        public string Login => loginText.text; // ��������, ���������� ���� �����
        public string Password => passwordText.text; // ��������, ���������� �������� ������

        public event Action OnBackButtonClicked; // ������� ������ �������
        public event Action OnRegistrationButtonClicked; // ������� ������ ����������� 

        public void Hide()
        {
            gameObject.SetActive(false); // ������
        }

        public void Show()
        {
            gameObject.SetActive(true); // ����������
        }

        public void Initialize()
        {
            backButton.onClick.AddListener(OnBackButtonClickedUnity); // ������ ��������� �� ����� OnBackButtonClickedUnity ������� �������� �������
            registrationButton.onClick.AddListener(OnRegistrationButtonClickedUnity); // ������ ��������� �� ����� OnRegistrationButtonClickedUnity ������� �������� �������
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveAllListeners();
            registrationButton.onClick.RemoveAllListeners();
            // ���
            /*backButton.onClick.RemoveListener(OnBackButtonClickedUnity);
            registrationButton.onClick.RemoveListener(OnRegistrationButtonClickedUnity);*/
        }

        private void OnRegistrationButtonClickedUnity()
        {
            OnRegistrationButtonClicked?.Invoke();
        }

        private void OnBackButtonClickedUnity()
        {
            OnBackButtonClicked?.Invoke();
        }
    }
}