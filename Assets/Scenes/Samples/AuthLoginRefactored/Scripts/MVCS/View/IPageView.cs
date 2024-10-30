using System.Drawing;

namespace AuthLoginSample.View
{
    public interface IPageView // ���������, ���������� ��� �������� ��������
    {
        public void Show(); // ��������
        public void Hide(); // ������
        public void Initialize();

    }
}