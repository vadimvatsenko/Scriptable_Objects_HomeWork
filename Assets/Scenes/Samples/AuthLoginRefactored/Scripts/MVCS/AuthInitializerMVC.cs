using System;
using Assets.Scenes.Samples.AuthLoginRefactored.Scripts.MVCS.View;
using AuthLoginSample.Controler;
using AuthLoginSample.Model;
using AuthLoginSample.View;
using UnityEngine;

public class AuthInitializerMVC : MonoBehaviour // �������������, ����� ������ �� ������ ������� �� �����
{
    [SerializeField] private LoginPageView loginPageView; // �������� �����������
    [SerializeField] private RegistrationPageView registrationPageView; // �������� �����������
    [SerializeField] private ProfilePageView profilePageView; // �������� ������� 
    [SerializeField] private NotifyPageView notifyPageView;
    
    private PageRoutingModel pageRoutingModel; // ������������� ��������
    private UserModel userModel; // ������������� �����
    private RegistrationController registrationController; 
    private PageRoutingController pageRoutingController;
    private AuthLoginSample.Service.FireBaseService fireBaseService; // ������������� Firebase

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        pageRoutingModel = new (); // ��������� ��������
        userModel = new (); // ��������� �����
        fireBaseService = new(notifyPageView); // ��������� Firebase

        loginPageView.Initialize(); // ������������� loginPageView ��� �������� ���������
        registrationPageView.Initialize(); // // ������������� registrationPageView ��� �������� ���������
        profilePageView.Initialize();

        pageRoutingController = new(pageRoutingModel, loginPageView, registrationPageView, profilePageView);
        // ��������� ���������� ����������, 

        pageRoutingController.Initialize();

        registrationController = new(registrationPageView, loginPageView, profilePageView, fireBaseService, pageRoutingController);

        registrationController.Initialize();
    }
}