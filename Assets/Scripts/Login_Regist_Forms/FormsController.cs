using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FormsController : MonoBehaviour
{
    [SerializeField] GameObject loginPanel;
    [SerializeField] GameObject registPanel;
    [SerializeField] GameObject forgotPassPanel;
    [SerializeField] GameObject profilePanel;
    [SerializeField] GameObject editUserForm;

    //private FireBaseService _firebaseService;

    private void OnEnable()
    {
  
        FireBaseService.OnLoginSuccess += OpenProfileMenu;//
    }

    private void OnDisable()
    {
        FireBaseService.OnLoginSuccess -= OpenProfileMenu;
    }
    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        registPanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        profilePanel.SetActive(false);
        editUserForm.SetActive(false);
    }

    public void OpenRegistPanel()
    {
        loginPanel.SetActive(false);
        registPanel.SetActive(true);
        forgotPassPanel.SetActive(false);
        profilePanel.SetActive(false);
        editUserForm.SetActive(false);
    }

    public void OpenProfileMenu()
    {
        Debug.Log("OpenProfileMenu");
        loginPanel.SetActive(false);
        registPanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        profilePanel.SetActive(true);
        editUserForm.SetActive(false);
    }

    public void OpenForgotPass()
    {
        loginPanel.SetActive(false);
        registPanel.SetActive(false);
        forgotPassPanel.SetActive(true);
        profilePanel.SetActive(false);
        editUserForm.SetActive(false);
    }

    public void OpenEditUserForm()
    {
        loginPanel.SetActive(false);
        registPanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        profilePanel.SetActive(false);
        editUserForm.SetActive(true);
    }
}
