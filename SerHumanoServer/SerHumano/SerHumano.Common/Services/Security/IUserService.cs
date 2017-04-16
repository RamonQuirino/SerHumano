using SerHumano.Common.Models.Security;

namespace SerHumano.Common.Services.Security
{
    public interface IUserService
    {
        User GetByLogin(string login);
    }
}
