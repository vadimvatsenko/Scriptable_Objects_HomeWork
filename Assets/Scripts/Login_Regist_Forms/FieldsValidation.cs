using System.Text.RegularExpressions;
using UnityEngine;

public class FieldsValidation 
{
    //private Notify _notify => new Notify();
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
            Debug.Log("Поле с паролем пустое, Ошибка");
            return false;
        }

        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMiniMaxChars = new Regex(@".{6,12}");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");


        if (!hasLowerChar.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Ошибка", "Пароль должен содержать хотя бы одну строчную букву");
            return false;
        }
        else if (!hasUpperChar.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Ошибка", "Пароль должен содержать хотя бы одну заглавную букву");
            return false;
        }
        else if (!hasMiniMaxChars.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Ошибка", "Пароль должен быть длиннее 6 символов");
            return false;
        }
        else if (!hasNumber.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Ошибка", "Пароль должен содержать хотя бы одно числовое значение");
            return false;
        }

        else if (!hasSymbols.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Ошибка", "Пароль должен содержать хотя бы один спец. символ");
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
            _notifyPanel.ShowNotificationMessage("Ошибка", "Поле с email пустое");
            return false;
        }

        // Регулярное выражение для валидации email
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        
        if (!emailRegex.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("Ошибка", "Некорректный формат email");
            return false;
        }
        return true;
    }
}
