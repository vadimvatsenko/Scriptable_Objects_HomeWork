using Firebase.Auth;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class FireBaseService
{
    public FirebaseAuth _auth { get; private set; }
    public FirebaseUser _user { get; private set; }
    private Notify _notify => new Notify();

    public static event Action OnLoginSuccess;

    public FireBaseService()
    {
        _auth = FirebaseAuth.DefaultInstance;
        _user = _auth.CurrentUser;
    }

    public void RegisterNewUser(string email, string password) // регистрация
    {
        
            _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.Log("Miss1");
                    _notify.CreateNotify("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.Log("Miss2");
                    _notify.CreateNotify("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                AuthResult result = task.Result;
                _notify.CreateNotify($"Firebase user created successfully: {result.User.UserId} - {result.User.Email}");
                _user = result.User;
                //SendEmailVerification();
            });
        
    }

    public void LoginInSystem(string email, string password) // логин
    {
        /*email = "vadim.vatsenko@gmail.com";
        password = "Vvn28091984!";*/
        Debug.Log($"email {email} password {password}");
        _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                _notify.CreateNotify("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            AuthResult result = task.Result;
            //_notify.CreateNotify($"Firebase user created successfully: {result.User.Email} - {result.User.UserId}");
            
            OnLoginSuccess?.Invoke();
            Debug.Log("Success");
        });
    }

    public void SendEmailVerification() // письмо с верификацией
    {
        if (_user != null)
        {
            _user.SendEmailVerificationAsync().ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("SendEmailVerificationAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SendEmailVerificationAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("Email sent successfully.");
            });
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
                Debug.Log("Signed in " + _user.UserId);
                //_nameProfilePanelText.text = _user.DisplayName ?? "";
                //_emailProfilePanelText.text = _user.Email ?? "";

                //OnAutoLogin?.Invoke();
                // photoUrl = _user.PhotoUrl.ToString() ?? "";////
            }
        }
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
            _user.UpdateUserProfileAsync(profile).ContinueWith(task => {
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
