using AuthLoginSample.Utils;

namespace AuthLoginSample.Model
{
    public class PageRoutingModel // 
    {
        public Observable<CurrentPage> CurrentPage { get; private set; } = new(Model.CurrentPage.Login);  // тут будет хранится текущая страница,
                                                                                                          // в данном случае это Login,                                                                                                          // в других классах можно будет перезаписывать  значение                                                                                                        // другое значение
    }
}