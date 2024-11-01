using System;
using System.Collections.Generic;

namespace AuthLoginSample
{
    public class PageRoutingController 
    {
        private readonly PageRoutingModel pageRoutingModel; // страница Дженерик
        private readonly LoginPageView loginPageView; // страница логинизации
        private readonly RegistrationPageView registrationPageView; // страница регистрации
        private readonly ProfilePageView profilePageView; // страница профиля

        private readonly Dictionary<CurrentPage, IPageView> pagesHash = new(); // словарь, который хранит текущую страницу и ее View

        public PageRoutingController(PageRoutingModel pageRoutingModel, 
                                        LoginPageView loginPageView, 
                                        RegistrationPageView registrationPageView,
                                        ProfilePageView profilePageView)
        {
            this.pageRoutingModel = pageRoutingModel; // PageRoutingModel находится класс в который записывается страница
            this.loginPageView = loginPageView; // страница логинизации
            this.registrationPageView = registrationPageView; // страница регистрации
            this.profilePageView = profilePageView;

            pagesHash.Add(CurrentPage.Login, loginPageView); // добавление в словарь страницы логина
            pagesHash.Add(CurrentPage.Registration, registrationPageView); // добавление в словарь страницы регистрации
            pagesHash.Add(CurrentPage.Profile, profilePageView);
        }

        public void Initialize()
        {
            pageRoutingModel.CurrentPageValue.OnValueChanged += OnPageChanged; // подписка на смену страницы
            loginPageView.OnRegisterClicked += OnRegisterClicked; // подписка на нажатие кнопки регистрации
            registrationPageView.OnBackButtonClicked += OnBackClicked; // подписка на нажатие кнопки обратно
        }

        ~PageRoutingController()
        {
            pageRoutingModel.CurrentPageValue.OnValueChanged -= OnPageChanged; // подписка на смену страницы
            loginPageView.OnRegisterClicked -= OnRegisterClicked; // подписка на нажатие кнопки регистрации
            registrationPageView.OnBackButtonClicked -= OnBackClicked; // подписка на нажатие кнопки обратно
        }

        private void OnBackClicked()
        {
            pageRoutingModel.CurrentPageValue.Value = CurrentPage.Login; // клацнули назад, перешли на страницу логинизации
        }

        private void OnRegisterClicked()
        {
            pageRoutingModel.CurrentPageValue.Value = CurrentPage.Registration; // клацнули на кнопку регистрации
        }

        public void ChangePage(CurrentPage currentPage)
        {
            UnityEngine.Debug.Log("Change page invoked");
             pageRoutingModel.CurrentPageValue.Value = currentPage;
        }

        private void OnPageChanged(CurrentPage page1, CurrentPage page2) // метод который сменяет страницы
        {
            UnityEngine.Debug.Log("Start Change Pages");
            IPageView pageView1, pageView2;
            bool isContainsKey1 = pagesHash.TryGetValue(page1, out pageView1);
            bool isContainsKey2 = pagesHash.TryGetValue(page2, out pageView2);

            if (isContainsKey1 && isContainsKey2){
                pageView1.Hide();
                pageView2.Show();
                UnityEngine.Debug.Log($"OnPageChange page invoked from {page1} to {page2}");
            }
            else {
                UnityEngine.Debug.Log("Page isnt in dictionry");
            }
        }
    }
}