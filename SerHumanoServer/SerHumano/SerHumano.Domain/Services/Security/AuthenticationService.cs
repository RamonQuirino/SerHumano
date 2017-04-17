using SerHumano.Common.Services.Security;

namespace SerHumano.Domain.Services.Security
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUserService _userService;
        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public UserAccessToken AuthenticateAccess(string login, string pass)
        {
            var user =  _userService.GetByLoginAndPass(login, pass);
            if (user != null)
            {
                //gerar token
            }
            return null;
        }

    }
}
