using SerHumano.Common.Models.Security;

namespace SerHumano.Common.Services.Security
{
    public interface IUserService
    {
        User GetByLogin(string login);
        User GetByLoginAndPass(string login, string pass);
    }
}
