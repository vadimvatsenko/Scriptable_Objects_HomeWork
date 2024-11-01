using System;
using UnityEngine;

namespace AuthLoginSample
{
    public class AuthInitializerMVC : MonoBehaviour // инициализация, будет висеть на пустом объекте на сцене
    {
        [SerializeField] private LoginPageView loginPageView; // страница логинизации
        [SerializeField] private RegistrationPageView registrationPageView; // страница регистрации
        [SerializeField] private ProfilePageView profilePageView; // страница профиля 
        [SerializeField] private NotifyPageView notifyPageView;

        private PageRoutingModel _pageRoutingModel; // инициализация страницы
        private UserModel _userModel; // инициализация юзера
        private RegistrationController _registrationController;
        private LoginController _loginController;
        private PageRoutingController _pageRoutingController;
        private FireBaseService _fireBaseService; // инициализация Firebase
        private ValidationService _validationService;

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            
            _pageRoutingModel = new PageRoutingModel(); // экземпляр страницы
            _userModel = new UserModel(); // экземпляр юзера
            
            
            loginPageView.Initialize(); // инициализация loginPageView там вешаются слушатели
            registrationPageView.Initialize(); // // инициализация registrationPageView там вешаются слушатели
            profilePageView.Initialize();
            notifyPageView.Initialize();
            _validationService = new ValidationService(notifyPageView);
            _fireBaseService = new(notifyPageView); // экземпляр Firebase
            _pageRoutingController = new(_pageRoutingModel, loginPageView, registrationPageView, profilePageView);
            // экземпляр управления страницами, 

            _pageRoutingController.Initialize();

            _registrationController = new(registrationPageView, loginPageView, profilePageView, _fireBaseService, _pageRoutingController);

            _registrationController.Initialize();

            _loginController = new(_fireBaseService, loginPageView, _pageRoutingController);
            _loginController.Initialize();


        }
    }
}
