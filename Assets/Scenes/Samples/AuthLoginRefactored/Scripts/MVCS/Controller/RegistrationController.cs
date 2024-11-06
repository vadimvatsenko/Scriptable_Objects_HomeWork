using System;


namespace AuthLoginSample
{
    public class RegistrationController // ��� ���������� ����������� ���� ������������
    {
        //Service
        private readonly FireBaseService fireBaseService; // ������ � �������� FireBase

        //View
        private readonly RegistrationPageView registrationPageView; // �������� ����������

        // Controller
        private readonly PageRoutingController pageRoutingController; // ���������� ����������

        public RegistrationController(RegistrationPageView registrationPageView,
                                      FireBaseService fireBaseService,
                                      PageRoutingController pageRoutingController)
        {
            this.registrationPageView = registrationPageView; // �������� �����������
            this.fireBaseService = fireBaseService; // ������ � �������� FireBase
            this.pageRoutingController = pageRoutingController; // ���������� ����������
        }

        public void Initialize() // ��� ������������� ���������� ��������
        {
            registrationPageView.OnRegistrationButtonClicked += OnRegistrationClicked;           

            this.fireBaseService.OnRegistSuccess += OnRegistSuccess;
        }

        ~RegistrationController()
        {
            registrationPageView.OnRegistrationButtonClicked -= OnRegistrationClicked;           

            this.fireBaseService.OnRegistSuccess -= OnRegistSuccess;
        }

        private void OnRegistSuccess() // ��� �������� ����������� ������ �������� �������� �� �����
        {
            pageRoutingController.ChangePage(CurrentPage.Login);
        }

        private void OnRegistrationClicked() // ����� ������� �����������
        {
            fireBaseService.RegisterNewUser(registrationPageView.Login, registrationPageView.Password, registrationPageView.ConfirmPassword);
        }
    }
}