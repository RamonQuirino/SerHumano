using SerHumano.Common.Models.Security;

namespace SerHumano.Domain.Repositories.Security
{
    public interface IUserRepository
    {
        User GetByLogin(string login);
        User GetByLoginAndPass(string login, string pass)
    }
}
