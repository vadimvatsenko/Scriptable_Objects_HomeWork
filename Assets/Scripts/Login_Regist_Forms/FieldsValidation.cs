using System.Text.RegularExpressions;
using UnityEngine;

public class FieldsValidation 
{
    private NotifyPanel _notifyPanel;
    public FieldsValidation(NotifyPanel notifyPanel) 
    {
        _notifyPanel = notifyPanel;
    }

    public bool PassWordValidation(string password)
    {
        string input = password;

        if (string.IsNullOrWhiteSpace(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Password field is empty", Color.red);
            return false;
        }

        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMiniMaxChars = new Regex(@".{6,12}");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");


        if (!hasLowerChar.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Password must contain at least one lowercase letter", Color.red);
            return false;
        }
        else if (!hasUpperChar.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Password must contain at least one capital letter", Color.red);
            return false;
        }
        else if (!hasMiniMaxChars.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Password must be longer than 6 characters", Color.red);
            return false;
        }
        else if (!hasNumber.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Password must contain at least one numeric value", Color.red);
            return false;
        }

        else if (!hasSymbols.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Password must contain at least one special character", Color.red);
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

        // Проверка на пустую строку
        if (string.IsNullOrWhiteSpace(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Email field is empty", Color.red);
            return false;
        }

        // Регулярное выражение для валидации email
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        
        if (!emailRegex.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Error", "Incorrect email format", Color.red);
            return false;
        }
        return true;
    }
}
