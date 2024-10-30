
using AuthLoginSample.Utils;

namespace AuthLoginSample.Model
{

    public class UserModel // ������ ����� �����
    {
        public Observable<string> Username { get; private set; }
        public Observable<string> UserId { get; private set; }
        public Observable<string> UserEmail { get; private set; }

    }
}