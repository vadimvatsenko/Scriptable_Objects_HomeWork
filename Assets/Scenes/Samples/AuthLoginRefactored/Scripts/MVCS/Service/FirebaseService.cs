namespace AuthLoginSample
{
    using Firebase;
    using Firebase.Auth;
    using System;
    using System.Threading.Tasks;
    using Unity.VisualScripting;
    using UnityEngine;

    public class FireBaseService // сервис FireBase
    {
        public FirebaseAuth _auth { get; private set; }
        public FirebaseUser _user { get; private set; }

        private Color SuccessColor => Color.green;
        private Color FailureColor => Color.red;

        private NotifyPageView _notifyPageView;
        private ValidationService _validationService;

        public event Action OnLoginSuccess;
        public event Action OnRegistSuccess;
        public event Action<FirebaseUser> OnStateChanged;
        public event Action OnAutoLogin;

        public FireBaseService(NotifyPageView notifyPageView, ValidationService validationService)
        {
            _auth = FirebaseAuth.DefaultInstance;
            _notifyPageView = notifyPageView;
            _validationService = validationService;            
        }

        public void Initialize()
        {
            _auth.StateChanged += AuthStateChanged;
            _user = _auth.CurrentUser;
            AuthStateChanged(this, null);
        }


        ~FireBaseService()
        {
            _auth.StateChanged -= AuthStateChanged;
            _auth = null;
        }

        public async void RegisterNewUser(string email, string password, string confirmPassword) 
        {
           
            if(_validationService.EmailValidation(email) && _validationService.PassWordValidation(password) && _validationService.PasswordEquals(password, confirmPassword))
            {
                Task<AuthResult> task = _auth.CreateUserWithEmailAndPasswordAsync(email, password);

                await task;

                try
                {
                    if (task.IsCanceled)
                    {
                        _notifyPageView.ShowMessage("Error", "CreateUserWithEmailAndPasswordAsync was canceled.", FailureColor);
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        _notifyPageView.ShowMessage("Error", "CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception, FailureColor);
                        return;
                    }

                    Firebase.Auth.AuthResult result = task.Result;

                    _notifyPageView.ShowMessage("Success", result.User.DisplayName + " " + result.User.UserId + " " + "regist success", Color.green);
                    OnRegistSuccess?.Invoke();
                }
                catch (FirebaseException ex)
                {
                    _notifyPageView.ShowMessage("Error", ex.Message, FailureColor);
                }
            }
            else
            {
                return;
            }            
        }

        public async void LoginInSystem(string email, string password) 
        {
            try
            {
                Task<AuthResult> task = _auth.SignInWithEmailAndPasswordAsync(email, password);
                await task;
                if (task.IsCanceled)
                {
                    _notifyPageView.ShowMessage("Error", "SignInWithEmailAndPasswordAsync was canceled.", FailureColor);
                    return;
                }

                if (task.IsFaulted)
                {
                    _notifyPageView.ShowMessage("Error", "SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception, FailureColor);
                    return;
                }

                AuthResult result = task.Result;

                _notifyPageView.ShowMessage("Success", result.User.DisplayName + " " + result.User.UserId + " " + "login success", Color.green);
                OnLoginSuccess?.Invoke();
            }
            catch (FirebaseException ex)
            {
                _notifyPageView.ShowMessage("Error", ex.Message, FailureColor);
            }                
        }

        public void AuthStateChanged(object sender, EventArgs eventArgs) 
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
                    //_notifyPageView.ShowMessage("Success", _user.UserId + "Enter Success", Color.green);
                    Debug.Log("Signed in " + _user.UserId);
                    OnAutoLogin?.Invoke();
                    OnStateChanged?.Invoke(_user);
                }
            }
        }

        public void QuitFromProfile()
        {
            _auth.SignOut();
        }
      
    }
}