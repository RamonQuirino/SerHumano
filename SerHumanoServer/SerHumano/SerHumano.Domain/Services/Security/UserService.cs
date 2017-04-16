using SerHumano.Common.Models.Security;
using SerHumano.Common.Services.Security;
using SerHumano.Domain.Repositories.Security;

namespace SerHumano.Domain.Services.Security
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }
    }
}
