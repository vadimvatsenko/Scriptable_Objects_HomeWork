using Firebase.Auth;
using System;
using System.Net.Mail;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireBaseApi : MonoBehaviour
{
    [Header("Login Panel")]
    [SerializeField] private TextMeshProUGUI _emailLoginFormText;
    [SerializeField] private TextMeshProUGUI _passwordLoginFormText;

    [Header("Registration Panel")]
    [SerializeField] private TextMeshProUGUI _emailRegistrationFormText;
    [SerializeField] private TextMeshProUGUI _passwordRegistrationFormText;
    [SerializeField] private TextMeshProUGUI _confirmPasswordRegistrationFormText;

    [Header("Edit User Info Panel")]
    [SerializeField] private TextMeshProUGUI _nameEditUserFormText;
    [SerializeField] private TextMeshProUGUI _emailEditUserFormText;

    [Header("Profile Panel")]
    [SerializeField] private TextMeshProUGUI _nameProfileFormText;
    [SerializeField] private TextMeshProUGUI _emailProfileFormText;

    [Header("Forgot Password Panel")]
    [SerializeField] private TextMeshProUGUI _emailForgotPasswordPanelText;

    public FireBaseService _firebaseService { get; private set; }  
    private FieldsValidation _validation;
    private bool _rememberMeToogle;

    public event Action OnRegistation; // для кнопки регистрации

    private void Awake()
    {
        _firebaseService = new FireBaseService();
        _validation = new FieldsValidation();
        _rememberMeToogle = FindAnyObjectByType<RememberMeToogle>().GetComponent<Toggle>().isOn;

        if (_rememberMeToogle)
        {
            /*_auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);*/
        }

    }

    private void OnDisable()
    {
        if (!_rememberMeToogle)
        {
            ExitFromAccount();
        }
    }

    public void RegistrationNewUser()
    {
        if (
            _validation.EmailValidation(_emailRegistrationFormText.text) 
            && _validation.PassWordValidation(_passwordRegistrationFormText.text) 
            && _passwordRegistrationFormText.text == _confirmPasswordRegistrationFormText.text)
        {
            _firebaseService.RegisterNewUser(_emailRegistrationFormText.text, _passwordRegistrationFormText.text);
        }
    }

    public void OnLoginUser()
    {
        _firebaseService.LoginInSystem(_emailLoginFormText.text, _passwordLoginFormText.text);
    }

    private void ExitFromAccount()
    {
        _firebaseService._auth.SignOut();
    }

    private void GetCurrentUser()
    {

    }
    /*public void AuthStateChangedWrap()
    {
        AuthStateChanged(this, null);
    }

    private void Exit()
    {
        _auth.SignOut();
    }*/
}
