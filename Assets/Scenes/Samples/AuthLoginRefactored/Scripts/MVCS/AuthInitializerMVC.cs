using System;
using UnityEngine;

namespace AuthLoginSample
{
    public class AuthInitializerMVC : MonoBehaviour // �������������, ����� ������ �� ������ ������� �� �����
    {
        [SerializeField] private LoginPageView loginPageView; // �������� �����������
        [SerializeField] private RegistrationPageView registrationPageView; // �������� �����������
        [SerializeField] private ProfilePageView profilePageView; // �������� ������� 
        [SerializeField] private NotifyPageView notifyPageView;

        private PageRoutingModel _pageRoutingModel; // ������������� ��������
        private UserModel _userModel; // ������������� �����
        private RegistrationController _registrationController;
        private LoginController _loginController;
        private PageRoutingController _pageRoutingController;
        private FireBaseService _fireBaseService; // ������������� Firebase
        private ValidationService _validationService;

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            
            _pageRoutingModel = new PageRoutingModel(); // ��������� ��������
            _userModel = new UserModel(); // ��������� �����
            
            
            loginPageView.Initialize(); // ������������� loginPageView ��� �������� ���������
            registrationPageView.Initialize(); // // ������������� registrationPageView ��� �������� ���������
            profilePageView.Initialize();
            notifyPageView.Initialize();
            _validationService = new ValidationService(notifyPageView);
            _fireBaseService = new(notifyPageView); // ��������� Firebase
            _pageRoutingController = new(_pageRoutingModel, loginPageView, registrationPageView, profilePageView);
            // ��������� ���������� ����������, 

            _pageRoutingController.Initialize();

            _registrationController = new(registrationPageView, loginPageView, profilePageView, _fireBaseService, _pageRoutingController);

            _registrationController.Initialize();

            _loginController = new(_fireBaseService, loginPageView, _pageRoutingController);
            _loginController.Initialize();


        }
    }
}
