using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FormsController : MonoBehaviour
{
    [SerializeField] GameObject loginPanel;
    [SerializeField] GameObject registPanel;
    [SerializeField] GameObject editUserForm;
    [SerializeField] GameObject forgotPassPanel;
    [SerializeField] GameObject profilePanel;

    private FireBaseApi _fireBaseApi;

    private void Start()
    {
        _fireBaseApi = GameObject.FindAnyObjectByType<FireBaseApi>();
        _fireBaseApi._firebaseService.OnLoginSuccess += OpenProfileMenu;
        _fireBaseApi._firebaseService.OnRegistSuccess += OpenLoginPanel;
    }

    private void OnDisable()
    {
        _fireBaseApi._firebaseService.OnLoginSuccess -= OpenProfileMenu;//
        _fireBaseApi._firebaseService.OnRegistSuccess -= OpenLoginPanel;
    }
    public void OpenLoginPanel()
    {
        Debug.Log("OpenLoginPanel");
        loginPanel.SetActive(true);
        registPanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        profilePanel.SetActive(false);
        //editUserForm.SetActive(false);
    }

    public void OpenRegistPanel()
    {
        loginPanel.SetActive(false);
        registPanel.SetActive(true);
        //forgotPassPanel.SetActive(false);
        profilePanel.SetActive(false);
        //editUserForm.SetActive(false);
    }

    public async void OpenProfileMenu()
    {        
        
            Debug.Log("OpenProfileMenu");
            loginPanel.SetActive(false);
            //registPanel.SetActive(false);
            //forgotPassPanel.SetActive(false);
            profilePanel.SetActive(true);
            //editUserForm.SetActive(false);

    }

    public void OpenForgotPass()
    {
        loginPanel.SetActive(false);
        registPanel.SetActive(false);
        forgotPassPanel.SetActive(true);
        profilePanel.SetActive(false);
        //editUserForm.SetActive(false);
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
