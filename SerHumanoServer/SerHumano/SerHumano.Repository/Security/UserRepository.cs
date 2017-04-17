using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SerHumano.Common.Models.Security;
using SerHumano.Domain.Repositories.Security;

namespace SerHumano.Repository.Security
{
    public class UserRepository: AbstractRepository, IUserRepository
    {
        public UserRepository(SerHumanoContext context):base(context)
        {
            
        }

        public User GetByLogin(string login)
        {
            return Context.Users.FirstOrDefault(x => x.Login == login);
        }

        public User GetByLoginAndPass(string login, string pass)
        {
            return Context.Users.FirstOrDefault(x => x.Login == login && x.Password == pass);                       
        }

    }
}
