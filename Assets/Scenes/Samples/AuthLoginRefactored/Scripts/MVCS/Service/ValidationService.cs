namespace AuthLoginSample.Service
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using UnityEngine;
    using static UnityEngine.Rendering.DebugUI;

    public class ValidationService  // сервис валидации полей
    {
        public bool PassWordValidation(string password)
        {
            string input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                UnityEngine.Debug.Log("Поле с паролем пустое, Ошибка");
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");


            if (!hasLowerChar.IsMatch(input))
            {
                UnityEngine.Debug.Log("Пароль должен содержать хотя бы одну строчную букву, Ошибка");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                UnityEngine.Debug.Log("Пароль должен содержать хотя бы одну заглавную букву, Ошибка");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                UnityEngine.Debug.Log("Пароль должен быть длиннее 6 символов, Ошибка");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                UnityEngine.Debug.Log("Пароль должен содержать хотя бы одно числовое значение, Ошибка");
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                UnityEngine.Debug.Log("Пароль должен содержать хотя бы один спец. символ, Ошибка");
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
                
                UnityEngine.Debug.Log("Поле с email пустое, Ошибка");
                return false;
            }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!emailRegex.IsMatch(input))
            {
                UnityEngine.Debug.Log("Некорректный формат email, Ошибка");
                return false;
            }

            return true;
        }
    }
}