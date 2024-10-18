using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class FieldsValidation 
{
    private Notify _notify => new Notify();
    public bool PassWordValidation(string password)
    {
        string input = password;

        if (string.IsNullOrWhiteSpace(input))
        {
            Debug.Log("���� � ������� ������, ������");
            return false;
        }

        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMiniMaxChars = new Regex(@".{6,12}");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");


        if (!hasLowerChar.IsMatch(input))
        {
            _notify.CreateNotify("������ ������ ��������� ���� �� ���� �������� �����, ������");
            return false;
        }
        else if (!hasUpperChar.IsMatch(input))
        {
            _notify.CreateNotify("������ ������ ��������� ���� �� ���� ��������� �����, ������");
            return false;
        }
        else if (!hasMiniMaxChars.IsMatch(input))
        {
            _notify.CreateNotify("������ ������ ���� ������� 6 ��������, ������");
            return false;
        }
        else if (!hasNumber.IsMatch(input))
        {
            _notify.CreateNotify("������ ������ ��������� ���� �� ���� �������� ��������, ������");
            return false;
        }

        else if (!hasSymbols.IsMatch(input))
        {
            _notify.CreateNotify("������ ������ ��������� ���� �� ���� ����. ������, ������");
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

        //������������������������
        if (string.IsNullOrWhiteSpace(input))
        {
            //Debug.Log("�����email�������,�������");
            _notify.CreateNotify("�����email�������,�������");
            return false;
        }

        //���������������������������������email
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        //������������������������������email
        if (!emailRegex.IsMatch(input))
        {
            _notify.CreateNotify("������������������email,�������");
            return false;
        }

        return true;
    }
}
