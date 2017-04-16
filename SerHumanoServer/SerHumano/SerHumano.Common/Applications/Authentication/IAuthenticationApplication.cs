using SerHumano.Common.Models.Security;

namespace SerHumano.Common.Applications.Authentication
{
    public interface IAuthenticationApplication
    {
        User GetByLogin(string login);
    }
}
