using AuthLoginSample.Utils;

namespace AuthLoginSample.Model
{
    public class PageRoutingModel // 
    {
        public Observable<CurrentPage> CurrentPage { get; private set; } = new(Model.CurrentPage.Login);  // ��� ����� �������� ������� ��������,
                                                                                                          // � ������ ������ ��� Login,                                                                                                          // � ������ ������� ����� ����� ��������������  ��������                                                                                                        // ������ ��������
    }
}