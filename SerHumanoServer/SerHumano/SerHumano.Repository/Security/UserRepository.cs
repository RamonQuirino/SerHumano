using System.Linq;
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
    }
}
