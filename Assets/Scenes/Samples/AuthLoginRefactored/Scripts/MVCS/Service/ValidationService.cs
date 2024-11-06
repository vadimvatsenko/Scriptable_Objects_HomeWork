namespace AuthLoginSample
{
    using System.Text.RegularExpressions;
    using UnityEngine;

    public class ValidationService  
    {
        private NotifyPageView _notifyPageView;
        private Color _errorColor => Color.red;

        public ValidationService(NotifyPageView notifyPageView)
        {
            _notifyPageView = notifyPageView;
        }

        public bool PassWordValidation(string password)
        {
            string input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                _notifyPageView.ShowMessage("Error", "The password field is empty", _errorColor);
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");


            if (!hasLowerChar.IsMatch(input))
            {
                _notifyPageView.ShowMessage("Error", "The password must contain at least one lowercase letter", _errorColor);
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                _notifyPageView.ShowMessage("Error", "The password must contain at least one capital letter", _errorColor);
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                _notifyPageView.ShowMessage("Error", "Password must be longer than 6 characters", _errorColor);
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                _notifyPageView.ShowMessage("Error", "The password must contain at least one numeric value", _errorColor);
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                _notifyPageView.ShowMessage("Error", "The password must contain at least one special password symbol", _errorColor);
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EmailValidation(string email)
        {
            var input = email;

            
            if (string.IsNullOrWhiteSpace(input))
            {

                _notifyPageView.ShowMessage("Error", "The email field is empty", _errorColor);
                return false;
            }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!emailRegex.IsMatch(input))
            {
                _notifyPageView.ShowMessage("Error", "Incorrect email format", _errorColor);
                return false;
            }

            return true;
        }

        public bool PasswordEquals(string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                _notifyPageView.ShowMessage("Error", "passwords don't match", Color.red);
                return false;
            } else
            {
                return true;
            }
        }
    }
}