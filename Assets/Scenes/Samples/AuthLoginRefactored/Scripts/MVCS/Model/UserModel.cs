using Firebase.Auth;

namespace AuthLoginSample
{

    public class UserModel // ������ ����� �����
    {
        public Observable<FirebaseUser> UserInfo { get; private set; } = new Observable<FirebaseUser>();    
        
    }
}