using SerHumano.Common.Applications.Authentication;
using SerHumano.Common.Models.Security;
using SerHumano.Common.Services.Person;
using SerHumano.Common.Services.Security;

namespace SerHumano.Application.Authentication
{
    public class AuthenticationApplication: IAuthenticationApplication
    {
        private readonly IPersonService _personService;
        private readonly IUserService _userService;

        public AuthenticationApplication(IPersonService personService, IUserService userService)
        {
            _personService = personService;
            _userService = userService;
        }

        public User GetByLogin(string login)
        {
            return _userService.GetByLogin(login);
        }

        public User GetByLoginAndPass(string login, string pass)
        {
            return _userService.GetByLoginAndPass(login, pass);
        }
    }
}
