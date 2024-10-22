using Firebase;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using Unity.VisualScripting;

using UnityEngine;

public class FireBaseService
{
    public FirebaseAuth _auth { get; private set; }
    public FirebaseUser _user { get; private set; }

    // private Task<AuthResult> _resultAsync; // 

    private NotifyPanel _notifyPanel;

    public event Action OnLoginSuccess;
    public event Action OnRegistSuccess;

    public FireBaseService(NotifyPanel notifyPanel)
    {
        _notifyPanel = notifyPanel;
        _auth = FirebaseAuth.DefaultInstance;
        _user = _auth.CurrentUser;
    }

    public async void RegisterNewUser(string email, string password) // регистрация
    {
        Task<AuthResult> resultAsync;
        try
        {
            resultAsync = _auth.CreateUserWithEmailAndPasswordAsync(email, password);

            await resultAsync;
            if (resultAsync.IsCanceled)
            {
                Debug.Log("Miss1");
                _notifyPanel.ShowNotificationMessage("Error", "CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (resultAsync.IsFaulted)
            {

                _notifyPanel.ShowNotificationMessage($"{resultAsync.Exception}", "CreateUserWithEmailAndPasswordAsync encountered an error");
                return;
            }

            AuthResult result = resultAsync.Result;
            _notifyPanel.ShowNotificationMessage("Firebase user created successfully", $"{result.User.UserId} - {result.User.Email}");
            _user = result.User;

            OnRegistSuccess?.Invoke();
            SendEmailVerification();

        }
        catch (FirebaseException ex)
        {

            _notifyPanel.ShowNotificationMessage($"{ex}", "CreateUserWithEmailAndPasswordAsync encountered an error");
        }

              
    }

    public async void LoginInSystem(string email, string password) // логин
    {

        try
        {
            Task <AuthResult> resultAsync = _auth.SignInWithEmailAndPasswordAsync(email, password);

            await resultAsync;

            if (resultAsync.IsCanceled)
            {
                _notifyPanel.ShowNotificationMessage("Error", "SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }

            if (resultAsync.IsFaulted)
            {
                _notifyPanel.ShowNotificationMessage($"{resultAsync.Exception}", "SignInWithEmailAndPasswordAsync encountered an error");
                return;
            }

            AuthResult result = resultAsync.Result;

            _notifyPanel.ShowNotificationMessage("Firebase user created successfully", $"{result.User.Email} - {result.User.UserId}");

            OnLoginSuccess?.Invoke();
        }
        catch (FirebaseException ex )
        {

            _notifyPanel.ShowNotificationMessage($"{ex}", "SignInWithEmailAndPasswordAsync encountered an error");
        }
        

        
    }

    public async void SendEmailVerification() // письмо с верификацией
    {
        if (_user != null)
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

                _notifyPanel.ShowNotificationMessage("Message", "Message send successful");
            }
            catch (FirebaseException ex)
            {
                Debug.LogError(ex);
                _notifyPanel.ShowNotificationMessage($"{ex}", "Error");
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

    public string[] AuthStateChanged(object sender, System.EventArgs eventArgs) // текущий пользователь
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
                Debug.Log("Signed in " + _user.UserId);

                return new string[]
                {
                    _user.DisplayName ?? "",
                    _user.Email ?? ""
                };
                //_nameProfilePanelText.text = _user.DisplayName ?? "";
                //_emailProfilePanelText.text = _user.Email ?? "";

                //OnAutoLogin?.Invoke();
                // photoUrl = _user.PhotoUrl.ToString() ?? "";////
            }
        }

        return null;
    }

    public void ChangeUserInfo()
    {
        if (_user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                //DisplayName = _nameProfilePanelText.text,
                //PhotoUrl = new System.Uri("https://example.com/jane-q-user/profile.jpg"),
            };
            _user.UpdateUserProfileAsync(profile).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }


                Debug.Log("User profile updated successfully.");
                //OnChangeSuccess?.Invoke();

            });
        }
    }

}
