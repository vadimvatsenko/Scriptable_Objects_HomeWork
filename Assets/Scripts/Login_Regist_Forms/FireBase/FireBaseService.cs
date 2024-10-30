using Firebase;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class FireBaseService
{
    public FirebaseAuth _auth { get; private set; }
    public FirebaseUser _user { get; private set; }

    private NotifyPanel _notifyPanel;

    public event Action OnLoginSuccess;
    public event Action OnRegistSuccess;

    public FireBaseService(NotifyPanel notifyPanel)
    {
        _notifyPanel = notifyPanel;
        _auth = FirebaseAuth.DefaultInstance;
              
        _auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    ~FireBaseService()
    {
        _auth.StateChanged -= AuthStateChanged;
        _auth = null;
    }

    public void AuthChangerWrap()
    {
        AuthStateChanged(this, null);
        
    }

    public async void RegisterNewUser(string email, string password) // регистрация
    {
        try
        {
            Task<AuthResult> resultAsync = _auth.CreateUserWithEmailAndPasswordAsync(email, password);

            await resultAsync;
            if (resultAsync.IsCanceled)
            {
                _notifyPanel.ShowNotificationMessage("Error", "CreateUserWithEmailAndPasswordAsync was canceled.", Color.red);
                return;
            }
            if (resultAsync.IsFaulted)
            {
                _notifyPanel.ShowNotificationMessage($"{resultAsync.Exception}", "CreateUserWithEmailAndPasswordAsync encountered an error", Color.red);
                return;
            }

            AuthResult result = resultAsync.Result;
            _notifyPanel.ShowNotificationMessage("Firebase user created successfully", $"{result.User.UserId} - {result.User.Email}", Color.green);
            _user = result.User;

            OnRegistSuccess?.Invoke();
            //SendEmailVerification();

        }
        catch (FirebaseException ex)
        {
            _notifyPanel.ShowNotificationMessage($"{ex}", "CreateUserWithEmailAndPasswordAsync encountered an error", Color.red);
        }
    }

    public async void LoginInSystem(string email, string password) // логин
    {

        try
        {
            Task<AuthResult> resultAsync = _auth.SignInWithEmailAndPasswordAsync(email, password);

            await resultAsync;

            if (resultAsync.IsCanceled)
            {
                _notifyPanel.ShowNotificationMessage("Error", "SignInWithEmailAndPasswordAsync was canceled.", Color.red);
                return;
            }

            if (resultAsync.IsFaulted)
            {
                _notifyPanel.ShowNotificationMessage($"{resultAsync.Exception.Message}", "SignInWithEmailAndPasswordAsync encountered an error", Color.red);
                return;
            }

            AuthResult result = resultAsync.Result;

            _notifyPanel.ShowNotificationMessage(
                            "User Enter Successful",
                            $"User Name: {(string.IsNullOrEmpty(result.User.DisplayName) ? "Underfined" : result.User.DisplayName)}, \n" +
                            $"User Email: {result.User.Email}, \n" +
                            $"UserID: {result.User.UserId}",
                            Color.green);



            OnLoginSuccess?.Invoke();
        }
        catch (FirebaseException ex)
        {
            _notifyPanel.ShowNotificationMessage($"{ex.Message}", "SignInWithEmailAndPasswordAsync encountered an error", Color.red);
        }
    }

    public async void SendEmailVerification() // письмо с верификацией
    {
        if (_auth.CurrentUser != null)
        {

            try
            {
                Task resultAsync = _user.SendEmailVerificationAsync();
                await resultAsync;

                if (resultAsync.IsCanceled)
                {
                    Debug.LogError("SendEmailVerificationAsync was canceled.");
                    return;
                }
                if (resultAsync.IsFaulted)
                {
                    Debug.LogError("SendEmailVerificationAsync encountered an error: " + resultAsync.Exception);
                    return;
                }

                _notifyPanel.ShowNotificationMessage("Message", "Message send successful", Color.green);
            }
            catch (FirebaseException ex)
            {
                Debug.LogError(ex.Message);
                _notifyPanel.ShowNotificationMessage($"{ex.Message}", "Error Send Verify Message", Color.red);
            }

        }
    }

    public void SendPasswordResetEmail(string email) // сброс пароля
    {
        email = email.ToString().ToLower();

        _auth.SendPasswordResetEmailAsync(email).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SendPasswordResetEmailAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
                return;
            }

            Debug.Log("Password reset email sent successfully.");
        });
    }

    public void AuthStateChanged(object sender, System.EventArgs eventArgs) // текущий пользователь
    {
        
        if (_auth.CurrentUser != _user)
        {
            bool signedIn = _user != _auth.CurrentUser && _auth.CurrentUser != null
                && _auth.CurrentUser.IsValid();
            if (!signedIn && _user != null)
            {
                Debug.Log("Signed out " + _user.UserId);
            }

            _user = _auth.CurrentUser;
            
            if (signedIn)
            {
                _notifyPanel.ShowNotificationMessage(
                             "User Enter Successful",
                             $"User Name: {(string.IsNullOrEmpty(_user.DisplayName) ? "Underfined" : _user.DisplayName)}, \n" +
                             $"User Email: {_user.Email}, \n" +
                             $"UserID: {_user.UserId}",
                             Color.green);


                //OnLoginSuccess?.Invoke();

                if (OnLoginSuccess != null)
                {
                    Debug.Log("Invoking OnLoginSuccess");
                    OnLoginSuccess.Invoke();
                }
                else
                {
                    Debug.Log("No subscribers for OnLoginSuccess");
                }
            }
        }
    }

}
