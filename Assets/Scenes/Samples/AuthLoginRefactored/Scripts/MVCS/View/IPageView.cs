using System.Drawing;

namespace AuthLoginSample.View
{
    public interface IPageView // интерфейс, показывать или скрывать страницу
    {
        public void Show(); // показать
        public void Hide(); // скрыть
        public void Initialize();

    }
}