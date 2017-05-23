using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerHumano.Common.Applications.Authentication;
using SerHumano.Common.Models.Security;

namespace SerHumano.Portal.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationApplication _authenticationApplication;
        private readonly SignInManager<ApplicationUser> _logiInManager;
        private readonly UserManager<ApplicationUser> _secManager;


        public AuthenticationController(IAuthenticationApplication authenticationApplication, SignInManager<ApplicationUser> logiInManager, UserManager<ApplicationUser> secManager)
        {
            _authenticationApplication = authenticationApplication;
            _logiInManager = logiInManager;
            _secManager = secManager;
        }

        [AllowAnonymous]        
        public IActionResult Login()
        {
            var usuario = _authenticationApplication.GetByLogin("ramon");
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await _secManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _logiInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            return View(model);
        }


        //6
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _logiInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToReturnUrl(returnUrl);
                }
            }


            return View(model);
        }

        //7
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _logiInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        //8
        private IActionResult RedirectToReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
