using System;


namespace AuthLoginSample
{
    public class RegistrationController // тут происходит регистрация всех контроллеров
    {
        //Service
        private readonly FireBaseService fireBaseService; // сервис с методами FireBase

        //View
        private readonly RegistrationPageView registrationPageView; // страница регистраци

        // Controller
        private readonly PageRoutingController pageRoutingController; // управление страницами

        public RegistrationController(RegistrationPageView registrationPageView,
                                      FireBaseService fireBaseService,
                                      PageRoutingController pageRoutingController)
        {
            this.registrationPageView = registrationPageView; // страница регистрации
            this.fireBaseService = fireBaseService; // сервис с методами FireBase
            this.pageRoutingController = pageRoutingController; // управление страницами
        }

        public void Initialize() // при инициализации происходит подписка
        {
            registrationPageView.OnRegistrationButtonClicked += OnRegistrationClicked;           

            this.fireBaseService.OnRegistSuccess += OnRegistSuccess;
        }

        ~RegistrationController()
        {
            registrationPageView.OnRegistrationButtonClicked -= OnRegistrationClicked;           

            this.fireBaseService.OnRegistSuccess -= OnRegistSuccess;
        }

        private void OnRegistSuccess() // при успешной регистрации меняем текующую страницу на логин
        {
            pageRoutingController.ChangePage(CurrentPage.Login);
        }

        private void OnRegistrationClicked() // вызов сервиса регистрации
        {
            fireBaseService.RegisterNewUser(registrationPageView.Login, registrationPageView.Password, registrationPageView.ConfirmPassword);
        }
    }
}