
namespace AuthLoginSample
{
    public class PageRoutingModel // 
    {
        public Observable<CurrentPage> CurrentPageValue { get; private set; } = new(CurrentPage.Login);  // ��� ����� �������� ������� ��������,
                                                                                                          // � ������ ������ ��� Login,                                                                                                          // � ������ ������� ����� ����� ��������������  ��������                                                                                                        // ������ ��������
    }
}