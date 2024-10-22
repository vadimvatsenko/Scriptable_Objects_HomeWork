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
            _notifyPanel.ShowNotificationMessage("������", "������ ������ ��������� ���� �� ���� �������� �����");
            return false;
        }
        else if (!hasUpperChar.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("������", "������ ������ ��������� ���� �� ���� ��������� �����");
            return false;
        }
        else if (!hasMiniMaxChars.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("������", "������ ������ ���� ������� 6 ��������");
            return false;
        }
        else if (!hasNumber.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("������", "������ ������ ��������� ���� �� ���� �������� ��������");
            return false;
        }

        else if (!hasSymbols.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("������", "������ ������ ��������� ���� �� ���� ����. ������");
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
            _notifyPanel.ShowNotificationMessage("������", "�����email�������");
            return false;
        }

        //���������������������������������email
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        
        if (!emailRegex.IsMatch(input))
        {
            _notifyPanel.ShowNotificationMessage("������", "������������������email");
            return false;
        }
        return true;
    }
}
