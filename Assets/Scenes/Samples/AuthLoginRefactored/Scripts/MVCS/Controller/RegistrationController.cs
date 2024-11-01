using System;


namespace AuthLoginSample
{
    public class RegistrationController // ��� ���������� ����������� ���� ������������
    {
        //Service
        private readonly FireBaseService fireBaseService; // ������ � �������� FireBase

        //View
        private readonly LoginPageView loginPageView;
        private readonly RegistrationPageView registrationPageView; // �������� �����������
        private readonly ProfilePageView profilePageView;

        // Controller
        private readonly PageRoutingController pageRoutingController; // ���������� ����������

        public RegistrationController(RegistrationPageView registrationPageView,
                                       LoginPageView loginPageView,
                                       ProfilePageView profilePageView,
                                      FireBaseService fireBaseService,
                                      PageRoutingController pageRoutingController)
        {
            this.registrationPageView = registrationPageView; // �������� �����������
            this.fireBaseService = fireBaseService; // ������ � �������� FireBase
            this.pageRoutingController = pageRoutingController; // ���������� ����������
            this.loginPageView = loginPageView;
            this.profilePageView = profilePageView;
        }

        public void Initialize() // ��� ������������� ���������� ��������
        {
            registrationPageView.OnRegistrationButtonClicked += OnRegistrationClicked;
            //loginPageView.OnLoginClicked += OnEnterUserByEmailAndPassword;
            profilePageView.OnQuitClick += OnQuitClicked;

            this.fireBaseService.OnRegistSuccess += OnRegistSuccess;
            //this.fireBaseService.OnLoginSuccess += OnLoginSuccess; 
        }

        ~RegistrationController()
        {
            registrationPageView.OnRegistrationButtonClicked -= OnRegistrationClicked;
            loginPageView.OnLoginClicked -= OnEnterUserByEmailAndPassword;
            profilePageView.OnQuitClick -= OnQuitClicked;

            this.fireBaseService.OnRegistSuccess -= OnRegistSuccess;
            //this.fireBaseService.OnLoginSuccess -= OnLoginSuccess;
        }

        /*private void OnLoginSuccess()
        {
            pageRoutingController.ChangePage(CurrentPage.Profile);
        }*/
        private void OnRegistSuccess() // ��� �������� ����������� ������ �������� �������� �� �����
        {
            pageRoutingController.ChangePage(CurrentPage.Login);
        }

        private void OnRegistrationClicked() // ����� ������� �����������
        {
            fireBaseService.RegisterNewUser(registrationPageView.Login, registrationPageView.Password);
        }

        private void OnEnterUserByEmailAndPassword()
        {
            fireBaseService.LoginInSystem(loginPageView.Email, loginPageView.Password);
        }

        private void OnQuitClicked()
        {
            this.fireBaseService.QuitFromProfile();
            pageRoutingController.ChangePage(CurrentPage.Login);
        }
    }
}