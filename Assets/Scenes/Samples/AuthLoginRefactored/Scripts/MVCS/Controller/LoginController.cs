namespace AuthLoginSample
{
    public class LoginController
    {
        private readonly FireBaseService fireBaseService; 
        private readonly LoginPageView loginPageView;
        private readonly PageRoutingController pageRoutingController;

        public LoginController(FireBaseService fireBaseService, LoginPageView loginPageView, PageRoutingController pageRoutingController)
        {
            this.fireBaseService = fireBaseService;
            this.loginPageView = loginPageView;
            this.pageRoutingController = pageRoutingController;
        }

        public void Initialize()
        {
            loginPageView.OnLoginClicked += OnLoginClick;
            fireBaseService.OnLoginSuccess += Service_OnLoginSuccess;
        }

        private void Service_OnLoginSuccess()
        {
            pageRoutingController.ChangePage(CurrentPage.Profile);
        }

        private void OnLoginClick()
        {
            fireBaseService.LoginInSystem(loginPageView.Email, loginPageView.Password);
        }

    }
}
