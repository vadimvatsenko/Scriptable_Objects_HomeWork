using System;
using Assets.Scenes.Samples.AuthLoginRefactored.Scripts.MVCS.View;
using AuthLoginSample.Controler;
using AuthLoginSample.Model;
using AuthLoginSample.View;
using UnityEngine;

public class AuthInitializerMVC : MonoBehaviour // инициализация, будет висеть на пустом объекте на сцене
{
    [SerializeField] private LoginPageView loginPageView; // страница логинизации
    [SerializeField] private RegistrationPageView registrationPageView; // страница регистрации
    [SerializeField] private ProfilePageView profilePageView; // страница профиля 
    [SerializeField] private NotifyPageView notifyPageView;
    
    private PageRoutingModel pageRoutingModel; // инициализация страницы
    private UserModel userModel; // инициализация юзера
    private RegistrationController registrationController; 
    private PageRoutingController pageRoutingController;
    private AuthLoginSample.Service.FireBaseService fireBaseService; // инициализация Firebase

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        pageRoutingModel = new (); // экземпляр страницы
        userModel = new (); // экземпляр юзера
        fireBaseService = new(notifyPageView); // экземпляр Firebase

        loginPageView.Initialize(); // инициализация loginPageView там вешаются слушатели
        registrationPageView.Initialize(); // // инициализация registrationPageView там вешаются слушатели
        profilePageView.Initialize();

        pageRoutingController = new(pageRoutingModel, loginPageView, registrationPageView, profilePageView);
        // экземпляр управления страницами, 

        pageRoutingController.Initialize();

        registrationController = new(registrationPageView, loginPageView, profilePageView, fireBaseService, pageRoutingController);

        registrationController.Initialize();
    }
}