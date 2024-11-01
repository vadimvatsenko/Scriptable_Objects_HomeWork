using System.Drawing;

namespace AuthLoginSample
{
    public interface IPageView // ���������, ���������� ��� �������� ��������
    {
        public void Show(); // ��������
        public void Hide(); // ������
        public void Initialize();

    }
}