using System;
using AuthLoginSample.Model;
using AuthLoginSample.View;
using AuthLoginSample.Service;
using System.Diagnostics;
using UnityEditor.iOS.Xcode;
using Assets.Scenes.Samples.AuthLoginRefactored.Scripts.MVCS.View;

namespace AuthLoginSample.Controler{
    public class RegistrationController // тут происходит регистрация всех контроллеров
    {
        //Service
        private readonly Service.FireBaseService fireBaseService; // сервис с методами FireBase

        //View
        private readonly LoginPageView loginPageView;
        private readonly RegistrationPageView registrationPageView; // страница регистрации
        private readonly ProfilePageView profilePageView;

        // Controller
        private readonly PageRoutingController pageRoutingController; // управление страницами

        public RegistrationController(RegistrationPageView registrationPageView,
                                       LoginPageView loginPageView,
                                       ProfilePageView profilePageView,
                                      Service.FireBaseService fireBaseService,
                                      PageRoutingController pageRoutingController)
        {
            this.registrationPageView = registrationPageView; // страница регистрации
            this.fireBaseService = fireBaseService; // сервис с методами FireBase
            this.pageRoutingController = pageRoutingController; // управление страницами
            this.loginPageView = loginPageView;
            this.profilePageView = profilePageView;
        }

        public void Initialize() // при инициализации происходит подписка
        {
            registrationPageView.OnRegistrationButtonClicked += OnRegistrationClicked;
            loginPageView.OnLoginClicked += OnEnterUserByEmailAndPassword;
            profilePageView.OnQuitClick += OnQuitClicked;

            this.fireBaseService.OnRegistSuccess += OnRegistSuccess;
            this.fireBaseService.OnLoginSuccess += OnLoginSuccess; 
        }

        ~RegistrationController()
        {
            registrationPageView.OnRegistrationButtonClicked -= OnRegistrationClicked;
            loginPageView.OnLoginClicked -= OnEnterUserByEmailAndPassword;
            profilePageView.OnQuitClick -= OnQuitClicked;

            this.fireBaseService.OnRegistSuccess -= OnRegistSuccess;
            this.fireBaseService.OnLoginSuccess -= OnLoginSuccess;
        }

        private void OnLoginSuccess()
        {
            pageRoutingController.ChangePage(CurrentPage.Profile);
        }
        private void OnRegistSuccess() // при успешной регистрации меняем текующую страницу на логин
        {
            pageRoutingController.ChangePage(CurrentPage.Login);
        }

        private void OnRegistrationClicked() // вызов сервиса регистрации
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