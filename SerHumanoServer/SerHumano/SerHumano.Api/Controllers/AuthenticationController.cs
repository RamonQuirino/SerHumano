using Microsoft.AspNetCore.Mvc;
using SerHumano.Common.Applications.Authentication;
using SerHumano.Common.Models.Security;

namespace SerHumano.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController: Controller
    {
        private readonly IAuthenticationApplication _authenticationApplication;
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
            _authenticationApplication = authenticationApplication;
        }

        [HttpGet]
        public User Get()
        {
            return  _authenticationApplication.GetByLogin("ramon");            
        }
    }
}
