namespace AuthLoginSample
{

    public class UserModel // Запись имени юзера
    {
        public Observable<string> Username { get; private set; }
        public Observable<string> UserId { get; private set; }
        public Observable<string> UserEmail { get; private set; }

    }
}