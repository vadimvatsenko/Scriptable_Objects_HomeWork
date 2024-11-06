using Firebase.Auth;

namespace AuthLoginSample
{

    public class UserModel // Запись имени юзера
    {
        public Observable<FirebaseUser> UserInfo { get; private set; } = new Observable<FirebaseUser>();    
        
    }
}